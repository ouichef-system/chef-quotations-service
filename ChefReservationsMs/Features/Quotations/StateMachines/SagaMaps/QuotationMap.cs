using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChefReservationsMs.Features.Quotations.StateMachines.Instances;

namespace ChefReservationsMs.Features.Quotations.StateMachines.SagaMaps
{
    public class QuotationMap : SagaClassMap<Quotation>
    {
        protected override void Configure(EntityTypeBuilder<Quotation> entity, ModelBuilder model)
        {
            entity.HasIndex(x => new { x.CorrelationId })
                .IsUnique();

            entity.Property(x => x.CurrentState)
                .HasMaxLength(64);

            // If using Optimistic concurrency, otherwise remove this property
            entity.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
