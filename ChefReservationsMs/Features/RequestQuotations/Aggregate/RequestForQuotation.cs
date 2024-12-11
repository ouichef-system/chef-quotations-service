using ChefReservationsMs.Features.Chefs.Enums;
using ChefReservationsMs.Features.Quotations.Entities;
using ChefReservationsMs.Features.Quotations.StateMachines.Instances;
using MassTransit;

namespace ChefReservationsMs.Features.RequestQuotations.Aggregate
{
    public class RequestForQuotation : SagaStateMachineInstance, IEntity
    {
        public Guid CorrelationId { get; set; }
        public required string CurrentState { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public required string Name { get; set; }
        public required string MealType { get; set; }
        public int NumberOfPeople { get; set; }
        public required List<string> CuisinePreferences { get; set; }
        public required string Location { get; set; }
        public DateTimeOffset ReservationDate { get; set; }
        public string? StoveType { get; set; }
        public int NumberOfBurners { get; set; }
        public bool HasWorkingOven { get; set; }
        public string? ChefPreference { get; set; }
        public string? DietaryRestrictions { get; set; }
        public string? AdditionalComments { get; set; }
        public required string ContactEmail { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public ICollection<Quotation> Quotations { get; set; } = [];
        public byte[]? RowVersion { get; set; }
    }
}
