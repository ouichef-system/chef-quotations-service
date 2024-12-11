using MassTransit;

namespace ChefReservationsMs.Features.Chefs.Apis.Requests
{
    public record PendingRequestForQuotation
    {
        public string? State { get; init; } = "Requested";
        public DateTimeOffset? ReservationDate { get; init; }
        public DateTime? CreationDate { get; init; }
    }
}
