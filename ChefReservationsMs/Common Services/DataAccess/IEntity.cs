namespace ChefReservationsMs.Features.Quotations.Entities
{
    public interface IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
