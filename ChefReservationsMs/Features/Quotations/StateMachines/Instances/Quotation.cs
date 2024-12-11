using ChefReservationsMs.Features.Quotations.Entities;
using ChefReservationsMs.Features.RequestQuotations.Aggregate;
using MassTransit;

namespace ChefReservationsMs.Features.Quotations.StateMachines.Instances
{
    public class Quotation : SagaStateMachineInstance, IEntity
    {
        public Guid CorrelationId { get; set; }
        public required Guid ChefId { get; set; }
        public string? ChefName { get; set; }
        public required string CurrentState { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ChefComments { get; set; }
        public RequestForQuotation? RequestForQuotation { get; set; }
        public required Guid RequestForQuotationId { get; set; }
        public decimal Price { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}
