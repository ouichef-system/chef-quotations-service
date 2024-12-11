using ChefReservationsMs.Features.Quotations.Apis.Requests;
using ChefReservationsMs.Features.Quotations.Apis.Responses;
using ChefReservationsMs.Features.Quotations.StateMachines.Events;
using ChefReservationsMs.Features.Quotations.StateMachines.Responses;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefReservationsMs.Features.Quotations
{
    public static class QuotationsApi
    {
        public static void RegisterQuotationsApis(this WebApplication endpoint)
        {
            var quotations = endpoint.MapGroup("/quotations");

            quotations.MapPost("/", OpenQuotation);
            quotations.MapPut("/{quotationId}/quote", QuoteQuotation);
            quotations.MapPut("/{quotationId}/accept", AcceptQuotation);
        }

        public static async Task<Ok<QuotationOpenedByChefResponse>> OpenQuotation(CreateQuotation quotation, IPublishEndpoint publish, IRequestClient<QuotationStarted> requestClient)
        {
            var quotationRequested = new QuotationStarted
            {
                ChefId = quotation.ChefId,
                RequestForQuotationId = quotation.RequestForQuotationId,
                RequestedBy = quotation.CreatedBy
            };

            var response = await requestClient.GetResponse<QuotationOpenedByChef>(quotationRequested);

            return TypedResults.Ok(new QuotationOpenedByChefResponse { QuotationId = response.Message.QuotationId });
        }

        public static async Task<Accepted> QuoteQuotation(QuoteQuotation quotation, Guid quotationId, IPublishEndpoint publish)
        {
            var quotationQuoted = new QuotationQuoted
            {
                QuotationId = quotationId,
                ChefName = quotation.CreatedBy,
                ChefComments = quotation.AdditionalComments,
                Price = quotation.Price,
                QuotedBy = quotation.CreatedBy
            };

            await publish.Publish(quotationQuoted);

            return TypedResults.Accepted($"/quotations/{quotationQuoted.QuotationId}");
        }

        public static async Task<Accepted> AcceptQuotation(Guid quotationId, IPublishEndpoint publish)
        {
            var quotationAccepted = new QuotationAccepted
            {
                QuotationId = quotationId,
            };

            await publish.Publish(quotationAccepted);

            return TypedResults.Accepted($"/quotations/{quotationId}");
        }
    }
}
