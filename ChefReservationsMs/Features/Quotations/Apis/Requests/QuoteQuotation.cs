namespace ChefReservationsMs.Features.Quotations.Apis.Requests
{
    public record QuoteQuotation
    {
        public required string CreatedBy { get; init; }
        public required decimal Price { get; init; }
        public string? AdditionalComments { get; init; }
        public ICollection<string> Items { get; init; } = new List<string>();
    }
}
