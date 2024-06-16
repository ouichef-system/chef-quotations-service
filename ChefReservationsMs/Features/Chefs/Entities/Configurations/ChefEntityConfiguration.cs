using ChefReservationsMs.Features.Chefs.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefReservationsMs.Features.Chefs.Entities.Configurations
{
    public class ChefEntityConfiguration : IEntityTypeConfiguration<ChefEntity>
    {
        public void Configure(EntityTypeBuilder<ChefEntity> builder)
        {
            builder.HasData(Seed());
        }

        public static ChefEntity Seed()
        {
            var chef = new ChefEntity
            {
                Id = new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                Description = "Chef italiano",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CreatedBy = "jbasalo",
                Name = "Claudio Paolini",
                OverallScore = 5
            };

            return chef;
        }
    }
}
