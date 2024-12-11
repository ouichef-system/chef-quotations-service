using MassTransit;

namespace ChefReservationsMs.Features.RequestQuotations.Aggregate.Events
{
    public record QuotationSuccesfullyAccepted : CorrelatedBy<Guid>
    {
        public Guid RequestForQuotationId { get; init; }

        public Guid CorrelationId => RequestForQuotationId;
    }
}
