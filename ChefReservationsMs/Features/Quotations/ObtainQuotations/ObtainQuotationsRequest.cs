namespace ChefReservationsMs.Features.Quotations.ObtainQuotations
{
    public record ObtainQuotationsRequest
    {
        public int? PageNumber { get; init; } = 1;
        public int? PageSize { get; init; } = 10;
        public string? Status { get; init; }
        public string? ChefName { get; init; }
        public DateTimeOffset? ReservationDateFrom { get; init; }
        public DateTimeOffset? ReservationDateTo { get; init; }
    }
}
