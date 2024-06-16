using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChefReservationsMs.Features.SearchSystem.Entities
{
    public class ChefFoodIndex
    {
        public Guid Id => Guid.NewGuid();
        public string Name { get; set; }
        public string Type { get; set; }
        public double Score { get; set; }

        public override string ToString()
        {
            return $"La comida {Name} de tipo {Type} con una puntuacion de {Score}";
        }
    }
}
