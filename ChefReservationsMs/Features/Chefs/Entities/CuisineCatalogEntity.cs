using ChefReservationsMs.Features.Quotations.Entities;

namespace ChefReservationsMs.Features.Chefs.Entities
{
    public class CuisineCatalogEntity : IEntity
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public required string CuisineName { get; set; }
    }
}
