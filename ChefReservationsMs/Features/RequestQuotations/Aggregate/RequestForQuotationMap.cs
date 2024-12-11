using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChefReservationsMs.Features.RequestQuotations.Aggregate
{
    public class RequestForQuotationMap : SagaClassMap<RequestForQuotation>
    {
        protected override void Configure(EntityTypeBuilder<RequestForQuotation> entity, ModelBuilder model)
        {
            entity.HasIndex(x => new { x.CorrelationId })
                .IsUnique();

            entity.Property(x => x.MealType)
                .HasConversion<string>();

            entity.Property(x => x.CuisinePreferences)
                .HasConversion<string>();

            entity.Property(x => x.CurrentState)
                .HasMaxLength(64);

            // If using Optimistic concurrency, otherwise remove this property
            entity.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
