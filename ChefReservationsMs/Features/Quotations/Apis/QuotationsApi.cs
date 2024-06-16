using ChefReservationsMs.Features.Quotations.Apis.Requests;
using ChefReservationsMs.Features.Quotations.StateMachines.Events;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChefReservationsMs.Features.Quotations.Apis
{
    public static class QuotationsApi
    {
        public static void RegisterQuotationsApis(this WebApplication endpoint)
        {
            var quotations = endpoint.MapGroup("/quotations");

            quotations.MapPost("/", OpenQuotation);
            quotations.MapPut("/{quotationId}", QuoteQuotation);
            quotations.MapPut("/{quotationId}", AcceptQuotation);
        }

        public static async Task<NoContent> OpenQuotation(CreateQuotation quotation, IPublishEndpoint publish)
        {
            var quotationRequested = new QuotationStarted
            {
                ChefId = quotation.ChefId,
                RequestForQuotationId = quotation.RequestForQuotationId,
                RequestedBy = quotation.CreatedBy
            };

            await publish.Publish(quotationRequested);

            return TypedResults.NoContent();
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
