using ChefReservationsMs.Common_Services.QueryHandlers;
using ChefReservationsMs.Common_Services.Utils;
using ChefReservationsMs.Features.Chefs.Apis.Requests;
using ChefReservationsMs.Features.Chefs.Apis.Views;
using ChefReservationsMs.Features.Quotations;
using ChefReservationsMs.Features.Quotations.ObtainQuotations;
using ChefReservationsMs.Features.RequestQuotations.Aggregate.Events;
using ChefReservationsMs.Features.RequestQuotations.Apis.Requests;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.ObjectModel;

namespace ChefReservationsMs.Features.RequestQuotations.Apis
{
    public static class RequestQuotationsApi
    {
        public static void RegisterRequestQuotationsApi(this WebApplication endpoint)
        {
            var requestForQuotations = endpoint.MapGroup("/request-for-quotations");

            requestForQuotations.MapPost("/", RequestQuotation);
            requestForQuotations.MapGet("/chefs/{chefId}", AllPendingRequestForQuotationByChef);
            requestForQuotations.MapGet("/", AllPendingRequestForQuotation);

            //Special end-point for quotations since dependency is not working in the other api
            endpoint.MapGet("/quotations/", ObtainQuotations);
        }

        public static async Task<Ok<ViewModel<ReadOnlyCollection<QuotationView>>>> ObtainQuotations(
            RequestHandler<ObtainQuotationsRequest, ReadOnlyCollection<QuotationView>> quotationHandler,
            [AsParameters] ObtainQuotationsFilters filters,
            ILoggerFactory loggerFactory,
            CancellationToken cancellationToken)
        {
            var logger = loggerFactory.CreateLogger(nameof(RequestQuotationsApi));

            try
            {
                ObtainQuotationsRequest quotationRequest = new()
                {
                    ChefName = filters.ChefName,
                    PageNumber = filters.PageNumber,
                    PageSize = filters.PageSize,
                    ReservationDateFrom = filters.ReservationDateFrom,
                    ReservationDateTo = filters.ReservationDateTo,
                    Status = filters.Status
                };

                var pendingRequestForQuotations = await quotationHandler(quotationRequest, cancellationToken);

                return TypedResults.Ok(pendingRequestForQuotations);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "There was an exception in the end-point: {Message}", ex.Message);
                throw;
            }
        }

        public static async Task<Accepted> RequestQuotation(RequestQuotation quotation, IPublishEndpoint publish, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(nameof(QuotationsApi));

            logger.LogInformation("Requesting quotation: @{QuotationRequest}", quotation);

            try
            {
                var quotationRequested = new ClientRequestReceived
                {
                    Name = $"{quotation.FirstName} {quotation.LastName}",
                    MealType = quotation.MealType,
                    NumberOfPeople = quotation.NumberOfPeople,
                    CuisinePreferences = [.. quotation.CuisinePreferences, quotation.OtherCuisinePreference ?? string.Empty],
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

        public static async Task<Ok<ViewModel<ReadOnlyCollection<RequestForQuotation>>>> AllPendingRequestForQuotation(
            RequestHandler<PendingRequestForQuotation, ReadOnlyCollection<RequestForQuotation>> getRequestForQuotations,
            [AsParameters] PendingRequestForQuotation requestForQuotation,
            ILoggerFactory loggerFactory,
            CancellationToken cancellationToken)
        {
            var logger = loggerFactory.CreateLogger(nameof(QuotationsApi));

            try
            {
                var pendingRequestForQuotations = await getRequestForQuotations(requestForQuotation, cancellationToken);

                return TypedResults.Ok(pendingRequestForQuotations);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "There was an exception in the end-point: {Message}", ex.Message);
                throw;
            }
        }

        public static async Task<Ok<ViewModel<ReadOnlyCollection<ChefRequestForQuotation>>>> AllPendingRequestForQuotationByChef(
            RequestHandler<PendingChefRequestForQuotation, ReadOnlyCollection<ChefRequestForQuotation>> getRequestForQuotations,
            Guid chefId,
            ILoggerFactory loggerFactory,
            CancellationToken cancellationToken)
        {
            var logger = loggerFactory.CreateLogger(nameof(QuotationsApi));

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