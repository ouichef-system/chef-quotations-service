namespace ChefReservationsMs.Features.Quotations.StateMachines.Responses
{
    public record QuotationRequestArrived(
    Guid QuotationId,
    string Name,
    string MealType,
    int NumberOfPeople,
    string CuisinePreference,
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
