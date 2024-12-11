using ChefReservationsMs.Common_Services.DataAccess;
using ChefReservationsMs.Common_Services.QueryHandlers;
using ChefReservationsMs.Common_Services.Utils;
using ChefReservationsMs.Features.Chefs.Apis.Requests;
using ChefReservationsMs.Features.Chefs.Apis.Views;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.ObjectModel;

namespace ChefReservationsMs.Features.Chefs.Apis
{
    public static class ChefsApi
    {
        public static void RegisterChefsApis(this WebApplication endpoint)
        {
            var chefs = endpoint.MapGroup("/chefs");

            chefs.MapGet("/", RegisterChef);
        }

        public static async Task<Ok<ViewModel<ReadOnlyCollection<ChefRequestForQuotation>>>> RegisterChef(
            RequestHandler<PendingChefRequestForQuotation, ReadOnlyCollection<ChefRequestForQuotation>> getRequestForQuotations,
            ChefReservationsDbContext dbContext, 
            ILoggerFactory loggerFactory,
            CancellationToken cancellationToken)
        {
            var logger = loggerFactory.CreateLogger(nameof(RegisterChef));

            try
            {
                var pendingRequestForQuotations = await getRequestForQuotations(new PendingChefRequestForQuotation { ChefId = chefId }, cancellationToken);

                return TypedResults.Ok(pendingRequestForQuotations);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "There was an exception in the end-point: {Message}", ex.Message);
                throw;
            }
        }
    }
}
