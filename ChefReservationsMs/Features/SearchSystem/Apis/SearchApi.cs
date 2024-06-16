using ChefReservationsMs.Features.SearchSystem.Aggregates;
using ChefReservationsMs.Features.SearchSystem.Entities;

namespace ChefReservationsMs.Features.SearchSystem.Apis
{
    public static class SearchApi
    {
        public static void RegisterSearchApis(this WebApplication endpoint)
        {
            var searching = endpoint.MapGroup("/search");

            searching.MapGet("/", (string searchTerm, int qty) =>
            {
                var searchService = new ChefCatalogSearchAggregate();
                var result = searchService.SearchResults(searchTerm, qty);

                return Results.Ok(result);
            });

            searching.MapPost("/index-chefs", (List<ChefIndex> chefs) =>
            {
                var searchService = new ChefCatalogSearchAggregate();
                searchService.IndexCatalogItemsForSearch(chefs);

                return TypedResults.NoContent();
            });
        }
    }
}
