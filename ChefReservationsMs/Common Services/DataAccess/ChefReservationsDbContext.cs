using ChefReservationsMs.Features.Chefs.Entities;
using ChefReservationsMs.Features.Quotations.RequestQuotations;
using ChefReservationsMs.Features.Quotations.StateMachines.Instances;
using ChefReservationsMs.Features.Quotations.StateMachines.SagaMaps;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace ChefReservationsMs.Common_Services.DataAccess
{
    public class ChefReservationsDbContext(DbContextOptions options) : SagaDbContext(options)
    {
        public DbSet<RequestForQuotation> RequestForQuotations { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<ChefEntity> Chefs { get; set; }
        public DbSet<CuisineCatalogEntity> CuisineCatalogs { get; set; }
        public DbSet<FoodEntity> Foods { get; set; }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get
            {
                yield return new QuotationMap();
                yield return new RequestForQuotationMap();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChefReservationsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
