using ChefReservationsMs.Features.Chefs.Enums;

namespace ChefReservationsMs.Features.Chefs.Apis.Views
{
    public record ChefRequestForQuotation
    {
        public Guid RequestForQuotationId { get; init; }
        public required string MealType { get; init; }
        public int NumberOfPeople { get; init; }
        public required List<string> CuisinePreferences { get; init; }
        public required string Location { get; init; }
        public DateTimeOffset ReservationDate { get; init; }
        public required bool ChefAlreadyQuoted { get; init; }
    }
}
