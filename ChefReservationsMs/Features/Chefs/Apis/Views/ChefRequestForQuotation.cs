using ChefReservationsMs.Features.Chefs.Enums;

namespace ChefReservationsMs.Features.Chefs.Apis.Views
{
    public record ChefRequestForQuotation
    {
        public required MealType MealType { get; init; }
        public int NumberOfPeople { get; init; }
        public required CuisineType CuisinePreference { get; init; }
        public string? OtherCuisinePreference { get; init; }
        public required string Location { get; init; }
        public DateTimeOffset ReservationDate { get; init; }
        public required bool ChefAlreadyQuoted { get; init; }
    }
}
