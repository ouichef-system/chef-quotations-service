using ChefReservationsMs.Features.Quotations.Entities;

namespace ChefReservationsMs.Features.Chefs.Entities
{
    public class ChefEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double? OverallScore { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<FoodEntity> Foods { get; set; } = [];
    }
}
