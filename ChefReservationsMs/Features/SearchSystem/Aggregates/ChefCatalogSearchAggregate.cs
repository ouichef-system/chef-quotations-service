using Lucene.Net.Analysis.Es;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using LuceneDirectory = Lucene.Net.Store.Directory;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers.Classic;
using ChefReservationsMs.Features.SearchSystem.Entities;
using System.Reflection;

namespace ChefReservationsMs.Features.SearchSystem.Aggregates
{
    public class ChefCatalogSearchAggregate : IDisposable
    {
        const LuceneVersion Version = LuceneVersion.LUCENE_48;
        private readonly string _indexPath;
        private readonly LuceneDirectory _indexDirectory;
        private readonly Analyzer _spanishAnalyzer;
        private bool _disposedValue;

        public ChefCatalogSearchAggregate()
        {
            string indexName = "chef_index";
            _indexPath = Path.Combine(Environment.CurrentDirectory, indexName);
            _indexDirectory = FSDirectory.Open(_indexPath);
            _spanishAnalyzer = new SpanishAnalyzer(Version);
        }

        public bool IndexCatalogItemsForSearch(IReadOnlyCollection<ChefIndex> chefsCatalog)
        {
            try
            {
                IndexWriterConfig indexConfig = new(Version, _spanishAnalyzer)
                {
                    OpenMode = OpenMode.CREATE
                };
                using IndexWriter writer = new(_indexDirectory, indexConfig);

                foreach (var chef in chefsCatalog)
                {
                    Document doc =
                        [
                            new TextField("chef-search-term", chef.ToString(), Field.Store.YES),
                            new StringField($"{chef.GetType().Name}-Name", chef.Name, Field.Store.YES),
                            new StringField($"{chef.GetType().Name}-Description", chef.Description, Field.Store.YES),
                            new DoubleField($"{chef.GetType().Name}-OverallScore", chef.OverallScore, Field.Store.YES)
                        ];

                    foreach (var food in chef.Foods)
                    {
                        doc.Add(new DoubleField($"{food.GetType().Name}-Score", food.Score, new FieldType { IsIndexed = false, IsStored = true, NumericType = NumericType.DOUBLE }));
                        doc.Add(new StringField($"{food.GetType().Name}-Name", food.Name, Field.Store.YES));
                        doc.Add(new StringField($"{food.GetType().Name}-Type", food.Type, Field.Store.YES));
                        doc.Add(new StringField($"{food.GetType().Name}-Id", food.Id.ToString(), Field.Store.YES));
                    }

                    writer.AddDocument(doc);
                }

                writer.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public List<ChefIndex> SearchResults(string searchTerm, int quantity)
        {
            searchTerm = searchTerm.ToLowerInvariant();

            using SearcherManager searcherManager = new(_indexDirectory, new SearcherFactory());

            string[] allFieldNames = [.. GetPropertyNames(typeof(ChefIndex))];

            QueryParser parser = new(Version, "chef-search-term", _spanishAnalyzer)
            {
                PhraseSlop = 3
            };

            // Parse the search term with the MultiFieldQueryParser
            Query multiFieldQuery = parser.Parse(searchTerm);

            Query fuzzyQuery = new FuzzyQuery(new Term("chef-search-term", searchTerm), 2);

            // Combine the MultiFieldQueryParser and the fuzzy query
            BooleanQuery combinedQuery = new()
            {
                { multiFieldQuery, Occur.SHOULD },
                { fuzzyQuery, Occur.SHOULD }
            };

            List<ChefIndex> searchResults = [];

            IndexSearcher searcher = searcherManager.Acquire();

            try
            {
                TopDocs topDocs = searcher.Search(combinedQuery, n: quantity);

                foreach (var result in topDocs.ScoreDocs)
                {
                    Document resultDoc = searcher.Doc(result.Doc);

                    var chef = BuildChefIndexModel(resultDoc);

                    searchResults.Add(chef);
                }
            }
            finally
            {
                searcherManager.Release(searcher);
                searcherManager.Dispose();
            }

            return searchResults;
        }

        static List<string> GetPropertyNames(Type type)
        {
            List<string> propertyNames = new List<string>();

            // Get properties of the current type
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                propertyNames.Add($"{type.Name}-{property.Name}");

                // Check if the property is a class and get its properties
                if (property.PropertyType.IsClass && property.PropertyType.Namespace == type.Namespace)
                {
                    propertyNames.AddRange(GetPropertyNames(property.PropertyType));
                }

                // Check if the property is a collection and get the properties of its elements
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                {
                    Type elementType = property.PropertyType.GetGenericArguments().FirstOrDefault();
                    if (elementType != null && elementType.Namespace == type.Namespace)
                    {
                        propertyNames.AddRange(GetPropertyNames(elementType));
                    }
                }
            }

            return propertyNames;
        }

        private ChefIndex BuildChefIndexModel(Document resultDoc)
        {
            var foodName = resultDoc.GetFields($"{typeof(ChefFoodIndex).Name}-Name").Select(c => new ChefFoodIndex { Name = c.GetStringValue() });
            var score = resultDoc.GetFields($"{typeof(ChefFoodIndex).Name}-Score").Select(c => new ChefFoodIndex { Score = c.GetDoubleValue() ?? 0 });
            var type = resultDoc.GetFields($"{typeof(ChefFoodIndex).Name}-Type").Select(c => new ChefFoodIndex { Type = c.GetStringValue() });

            List<ChefFoodIndex> joinedList = foodName
                                            .Zip(score, (name, s) => new { name.Name, s.Score })
                                            .Zip(type, (temp, t) => new ChefFoodIndex { Name = temp.Name, Score = temp.Score, Type = t.Type })
                                            .ToList();

            var domain = new ChefIndex
            {
                Name = resultDoc.Get($"{typeof(ChefIndex).Name}-Name"),
                Description = resultDoc.Get($"{typeof(ChefIndex).Name}-Description"),
                OverallScore = double.Parse(resultDoc.Get($"{typeof(ChefIndex).Name}-OverallScore")),
                Foods = [.. joinedList]
            };

            return domain;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _indexDirectory.Dispose();
                    _spanishAnalyzer.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
