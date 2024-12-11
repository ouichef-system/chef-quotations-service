namespace ChefReservationsMs.Features.Quotations.ObtainQuotations
{
    public record QuotationView
    {
        public required string ChefName { get; init; }
        public required Guid ChefId { get; init; }
        public required string ClientName { get; init; }
        public required string MealType { get; init; }
        public int NumberOfPeople { get; init; }
        public required List<string> CuisinePreferences { get; init; }
        public required string Location { get; init; }
        public DateTimeOffset ReservationDate { get; init; }
        public required string StoveType { get; init; }
        public int NumberOfBurners { get; init; }
        public bool HasWorkingOven { get; init; }
        public string? ChefPreference { get; init; }
        public string? DietaryRestrictions { get; init; }
        public string? AdditionalComments { get; init; }
        public required string ContactEmail { get; init; }
        public string? ContactPhoneNumber { get; init; }
    }
}
