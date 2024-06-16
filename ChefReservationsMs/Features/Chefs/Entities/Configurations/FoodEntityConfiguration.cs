using ChefReservationsMs.Features.Chefs.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefReservationsMs.Features.Chefs.Entities.Configurations
{
    public class FoodEntityConfiguration : IEntityTypeConfiguration<FoodEntity>
    {
        public void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
            builder.Property(f => f.MealTypes)
                   .HasConversion(
                       v => string.Join(',', v.Select(mt => mt.ToString())),
                       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                             .Select(mt => Enum.Parse<MealType>(mt.Trim()))
                             .ToList());

            builder.HasData(Seed());
        }

        public static FoodEntity Seed()
        {
            var food = new FoodEntity
            {
                Id = new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                ChefId = new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                Name = "Fettucini a la parmessiana",
                MealTypes = [MealType.Dinner, MealType.Lunch],
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "jbasalo",
                CuisineTypeId = new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                Score = 2
            };

            return food;
        }
    }
}
