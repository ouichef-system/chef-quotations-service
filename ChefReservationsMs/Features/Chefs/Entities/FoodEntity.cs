using ChefReservationsMs.Features.Chefs.Enums;
using ChefReservationsMs.Features.Quotations.Entities;

namespace ChefReservationsMs.Features.Chefs.Entities
{
    public class FoodEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public required string Name { get; set; }
        public List<MealType> MealTypes { get; set; } = [];
        public CuisineCatalogEntity? CuisineType { get; set; }
        public required Guid CuisineTypeId { get; set; }
        public ChefEntity? Chef { get; set; }
        public required Guid ChefId { get; set; }
        public double? Score { get; set; }
    }
}
