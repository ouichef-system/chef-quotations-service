using ChefReservationsMs.Features.Quotations.RequestQuotations;
using MassTransit;

namespace ChefReservationsMs.Features.Notifications.Clients.Emails
{
    public class RequestForQuotationConsumer : IConsumer<RequestForQuotationCreated>
    {
        public async Task Consume(ConsumeContext<RequestForQuotationCreated> context)
        {
        }
    }
}
