using MassTransit;

namespace ChefReservationsMs.Features.Quotations.StateMachines.Events
{
    public record QuotationQuoted : CorrelatedBy<Guid>
    {
        public Guid CorrelationId => QuotationId;
        public Guid QuotationId { get; init; }
        public required string QuotedBy { get; init; }
        public required string ChefName { get; init; }
        public required decimal Price { get; init; }
        public string? ChefComments { get; init; }
    }
}
