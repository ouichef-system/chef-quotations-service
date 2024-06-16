
namespace ChefReservationsMs.Features.Quotations.StateMachines.Events
{
    public record QuotationRejected
    {
        public required Guid RequestForQuotationId { get; init; }
    }
}
