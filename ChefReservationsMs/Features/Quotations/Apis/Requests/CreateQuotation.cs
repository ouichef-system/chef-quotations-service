namespace ChefReservationsMs.Features.Quotations.Apis.Requests
{
    public record CreateQuotation
    {
        public required string CreatedBy { get; init; }
        public required Guid RequestForQuotationId { get; init; }
        public required Guid ChefId { get; init; }
    }
}
