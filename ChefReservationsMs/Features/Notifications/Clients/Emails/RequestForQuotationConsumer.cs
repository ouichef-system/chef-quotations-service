using ChefReservationsMs.Features.RequestQuotations.Aggregate.Responses;
using MassTransit;

namespace ChefReservationsMs.Features.Notifications.Clients.Emails
{
    public class RequestForQuotationConsumer : IConsumer<QuotationRequestArrived>
    {
        public async Task Consume(ConsumeContext<QuotationRequestArrived> context)
        {
        }
    }
}
