using MassTransit;

namespace ChefReservationsMs.Features.Quotations.StateMachines.Responses
{
    public record QuotationSuccesfullyAccepted : CorrelatedBy<Guid>
    {
        public Guid RequestForQuotationId { get; init; }

        public Guid CorrelationId => RequestForQuotationId;
    }
}
