using ChefReservationsMs.Features.Quotations.Apis;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefReservationsMs.Features.Quotations.RequestQuotations
{
    public static class RequestQuotationsApi
    {
        public static void RegisterRequestQuotationsApi(this WebApplication endpoint)
        {
            var quotations = endpoint.MapGroup("/request-for-quotations");

            quotations.MapPost("/request", RequestQuotation);
        }

        public static async Task<Accepted> RequestQuotation(RequestQuotation quotation, IPublishEndpoint publish, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(nameof(QuotationsApi));

            try
            {
                var quotationRequested = new ClientRequestReceived
                {
                    Name = quotation.Name,
                    MealType = quotation.MealType,
                    NumberOfPeople = quotation.NumberOfPeople,
                    CuisinePreference = quotation.CuisinePreference,
                    OtherCuisinePreference = quotation.OtherCuisinePreference,
                    Location = quotation.Location,
                    ReservationDate = quotation.ReservationDate,
                    StoveType = quotation.StoveType,
                    NumberOfBurners = quotation.NumberOfBurners,
                    HasWorkingOven = quotation.HasWorkingOven,
                    ChefPreference = quotation.ChefPreference,
                    DietaryRestrictions = quotation.DietaryRestrictions,
                    AdditionalComments = quotation.AdditionalComments,
                    ContactEmail = quotation.ContactEmail,
                    ContactPhoneNumber = quotation.ContactPhoneNumber
                };

                await publish.Publish(quotationRequested);

                return TypedResults.Accepted($"/quotations/{quotationRequested.RequestForQuotationId}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "There was an exception in the end-point: {Message}", ex.Message);
                throw;
            }
        }
    }
}