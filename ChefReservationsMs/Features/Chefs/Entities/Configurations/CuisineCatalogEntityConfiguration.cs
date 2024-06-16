using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefReservationsMs.Features.Chefs.Entities.Configurations
{
    public class CuisineCatalogEntityConfiguration : IEntityTypeConfiguration<CuisineCatalogEntity>
    {
        public void Configure(EntityTypeBuilder<CuisineCatalogEntity> builder)
        {
            builder.HasData(Seed());
        }

        public static CuisineCatalogEntity Seed()
        {
            var cuisine = new CuisineCatalogEntity
            {
                Id = new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "jbasalo",
                CuisineName = "Pasta"
            };

            return cuisine;
        }
    }
}
