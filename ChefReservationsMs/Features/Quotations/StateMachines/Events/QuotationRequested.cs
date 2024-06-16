
namespace ChefReservationsMs.Features.Quotations.StateMachines.Events
{
    public record QuotationStarted
    {
        public Guid RequestForQuotationId { get; init; }
        public Guid ChefId { get; init; }
        public required string RequestedBy { get; init; }
    }
}
