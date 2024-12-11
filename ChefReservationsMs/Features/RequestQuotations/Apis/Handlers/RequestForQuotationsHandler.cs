using ChefReservationsMs.Common_Services.DataAccess;
using ChefReservationsMs.Common_Services.QueryHandlers;
using ChefReservationsMs.Features.Chefs.Apis.Requests;
using ChefReservationsMs.Features.Chefs.Apis.Views;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ChefReservationsMs.Features.Chefs.Apis.Handlers
{
    public class RequestForQuotationsHandler(ChefReservationsDbContext chefReservationsContext, ILogger<RequestForQuotationsHandler> logger) 
        : IRequestHandler<PendingRequestForQuotation, ReadOnlyCollection<RequestForQuotation>>
    {
        private readonly ChefReservationsDbContext _chefReservationsContext = chefReservationsContext;
        private readonly ILogger<RequestForQuotationsHandler> _logger = logger;

        public async ValueTask<ViewModel<ReadOnlyCollection<RequestForQuotation>>> Handle(PendingRequestForQuotation request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving request for quotations for the admin.");

            var pendingRequestForQuotations = _chefReservationsContext.RequestForQuotations
                    .AsNoTracking()
                    .Include(rfq => rfq.Quotations)
                    .Where(rfq => rfq.ReservationDate >= DateTimeOffset.UtcNow && rfq.CurrentState == "Requested")
                    .AsSplitQuery();

            var result = await pendingRequestForQuotations.Select(x => new RequestForQuotation
            {
                RequestForQuotationId = x.CorrelationId,
                CuisinePreferences = x.CuisinePreferences,
                Location = x.Location,
                MealType = x.MealType,
                NumberOfPeople = x.NumberOfPeople,
                ReservationDate = x.ReservationDate,
                ChefAlreadyQuoted = x.Quotations.Count != 0
            }).ToListAsync(cancellationToken: cancellationToken);

            return new ViewModel<ReadOnlyCollection<RequestForQuotation>>
            {
                OperationId = NewId.NextSequentialGuid(),
                Data = new ReadOnlyCollection<RequestForQuotation>(result)
            };
        }
    }
}
