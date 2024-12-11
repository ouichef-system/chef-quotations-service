using ChefReservationsMs.Features.Chefs.Enums;

namespace ChefReservationsMs.Features.RequestQuotations.Apis.Requests
{
    public record RequestQuotation
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string MealType { get; init; }
        public int NumberOfPeople { get; init; }
        public required List<string> CuisinePreferences { get; init; }
        public string? OtherCuisinePreference { get; init; }
        public required string Location { get; init; }
        public DateTimeOffset ReservationDate { get; init; }
        public string? StoveType { get; init; }
        public int NumberOfBurners { get; init; }
        public bool HasWorkingOven { get; init; }
        public string? ChefPreference { get; init; }
        public string? DietaryRestrictions { get; init; }
        public string? AdditionalComments { get; init; }
        public required string ContactEmail { get; init; }
        public string? ContactPhoneNumber { get; init; }
    }
}
