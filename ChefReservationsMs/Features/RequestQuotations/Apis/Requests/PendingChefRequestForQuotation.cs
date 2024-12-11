using MassTransit;

namespace ChefReservationsMs.Features.Chefs.Apis.Requests
{
    public record PendingChefRequestForQuotation
    {
        public required Guid ChefId { get; init; }
        public Guid OperationId { get; init; } = NewId.NextSequentialGuid();
    }
}
