using MassTransit;

namespace ChefReservationsMs.Features.Quotations.StateMachines.Events
{
    public record QuotationAccepted : CorrelatedBy<Guid>
    {
        public Guid CorrelationId => QuotationId;
        public Guid QuotationId { get; init; }
    }
}
