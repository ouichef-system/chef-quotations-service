using ChefReservationsMs.Common_Services.DataAccess;
using ChefReservationsMs.Common_Services.QueryHandlers;
using ChefReservationsMs.Features.Chefs.Apis.Requests;
using ChefReservationsMs.Features.Chefs.Apis.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ChefReservationsMs.Features.Chefs.Apis.Handlers
{
    public class ChefRequestForQuotationsHandler(ChefReservationsDbContext chefReservationsContext, ILogger<ChefRequestForQuotationsHandler> logger) 
        : IRequestHandler<PendingChefRequestForQuotation, ReadOnlyCollection<ChefRequestForQuotation>>
    {
        private readonly ChefReservationsDbContext _chefReservationsContext = chefReservationsContext;
        private readonly ILogger<ChefRequestForQuotationsHandler> _logger = logger;

        public async ValueTask<ViewModel<ReadOnlyCollection<ChefRequestForQuotation>>> Handle(PendingChefRequestForQuotation request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving request for quotations for the chef: {ChefId}", request.ChefId);

            var pendingRequestForQuotations = _chefReservationsContext.RequestForQuotations
                    .AsNoTracking()
                    .Include(rfq => rfq.Quotations)
                    .Where(rfq => rfq.ReservationDate >= DateTimeOffset.UtcNow && rfq.CurrentState == "Pending")
                    .AsSplitQuery();

            var result = await pendingRequestForQuotations.Select(x => new ChefRequestForQuotation
            {
                CuisinePreference = x.CuisinePreference,
                Location = x.Location,
                MealType = x.MealType,
                NumberOfPeople = x.NumberOfPeople,
                OtherCuisinePreference = x.OtherCuisinePreference,
                ReservationDate = x.ReservationDate,
                ChefAlreadyQuoted = x.Quotations.Any(q => q.CurrentState != "Opened" && q.ChefId == request.ChefId)
            }).ToListAsync(cancellationToken: cancellationToken);

            return new ViewModel<ReadOnlyCollection<ChefRequestForQuotation>>
            {
                OperationId = request.OperationId,
                Data = new ReadOnlyCollection<ChefRequestForQuotation>(result)
            };
        }
    }
}
