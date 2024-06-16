using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChefReservationsMs.Features.SearchSystem.Entities
{
    public class ChefIndex
    {
        public Guid Id => Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public double OverallScore { get; set; }
        public ICollection<ChefFoodIndex> Foods { get; set; } = new List<ChefFoodIndex>();

        public override string ToString()
        {
            return @$"El chef {Name} con los siguientes datos {Description} con una puntuacion de {OverallScore}, cocina las siguientes comida:
                      {string.Join(", ", Foods.Select(f => f.ToString()))}";
        }
    }
}
