using ChefReservationsMs.Features.Chefs.Enums;
using MassTransit;

namespace ChefReservationsMs.Features.RequestQuotations.Aggregate.Events
{
    public record ClientRequestReceived : CorrelatedBy<Guid>
    {
        public Guid CorrelationId => RequestForQuotationId;
        public Guid RequestForQuotationId { get; set; } = NewId.NextSequentialGuid();
        public required string Name { get; init; }
        public string MealType { get; init; }
        public int NumberOfPeople { get; init; }
        public required List<string> CuisinePreferences { get; init; }
        public string? OtherCuisinePreference { get; init; }
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
