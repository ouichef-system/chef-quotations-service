namespace ChefReservationsMs.Features.Quotations.StateMachines.Responses
{
    public record QuotationOpenedByChef
    {
        public Guid QuotationId { get; init; }
    }
}
