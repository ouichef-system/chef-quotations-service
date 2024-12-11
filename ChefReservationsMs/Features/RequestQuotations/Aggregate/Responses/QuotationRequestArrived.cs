namespace ChefReservationsMs.Features.RequestQuotations.Aggregate.Responses
{
    public record QuotationRequestArrived(
    Guid QuotationId,
    string Name,
    string MealType,
    int NumberOfPeople,
    List<string> CuisinePreferences,
    string Location,
    DateTimeOffset ReservationDate,
    string StoveType,
    int NumberOfBurners,
    bool HasWorkingOven,
    string? ChefPreference,
    string? DietaryRestrictions,
    string? AdditionalComments,
    string ContactEmail);
}
