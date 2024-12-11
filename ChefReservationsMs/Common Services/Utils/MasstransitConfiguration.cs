using ChefReservationsMs.Common_Services.DataAccess;
using ChefReservationsMs.Features.Quotations.StateMachines.Events;
using MassTransit;
using System.Reflection;

namespace ChefReservationsMs.Common_Services.Utils
{
    public static class MasstransitConfiguration
    {
        public static IServiceCollection ConfigureMasstransit(this IServiceCollection services)
        {
            return services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                var entryAssembly = Assembly.GetEntryAssembly();

                x.SetEntityFrameworkSagaRepositoryProvider(r =>
                {
                    r.ExistingDbContext<ChefReservationsDbContext>();
                    r.UsePostgres();
                });
                x.AddSagaStateMachines(entryAssembly);
                x.AddSagas(entryAssembly);

                x.AddRequestClient<QuotationStarted>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.SetCustomEntityNameFormatter();

                    cfg.ConfigureJsonSerializerOptions(settings =>
                    {
                        return settings;
                    });

                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
