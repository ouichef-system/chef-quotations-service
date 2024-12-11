using ChefReservationsMs.Common_Services.DataAccess;
using ChefReservationsMs.Common_Services.QueryHandlers;
using ChefReservationsMs.Features.Quotations.StateMachines.Instances;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ChefReservationsMs.Features.Quotations.ObtainQuotations
{
    public class ObtainQuotationsHandler(ChefReservationsDbContext chefReservationsContext, ILogger<ObtainQuotationsHandler> logger) 
        : IRequestHandler<ObtainQuotationsRequest, ReadOnlyCollection<QuotationView>>
    {
        private readonly ChefReservationsDbContext _chefReservationsContext = chefReservationsContext;
        private readonly ILogger<ObtainQuotationsHandler> _logger = logger;
        public async ValueTask<ViewModel<ReadOnlyCollection<QuotationView>>> Handle(ObtainQuotationsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving request for quotations for the admin.");

            var pendingRequestForQuotations = _chefReservationsContext.Quotations
                .Include(q => q.RequestForQuotation)
                .AsNoTracking();

            pendingRequestForQuotations = ApplyFilters(pendingRequestForQuotations, request);

            var result = await pendingRequestForQuotations.Select(x => new QuotationView
            {
                ChefName = x.ChefName,
                ChefId = x.CorrelationId,
                ClientName = x.RequestForQuotation.Name,
                MealType = x.RequestForQuotation.MealType,
                NumberOfPeople = x.RequestForQuotation.NumberOfPeople,
                CuisinePreferences = x.RequestForQuotation.CuisinePreferences,
                Location = x.RequestForQuotation.Location,
                ReservationDate = x.RequestForQuotation.ReservationDate,
                StoveType = x.RequestForQuotation.StoveType,
                NumberOfBurners = x.RequestForQuotation.NumberOfBurners,
                HasWorkingOven = x.RequestForQuotation.HasWorkingOven,
                ChefPreference = x.RequestForQuotation.ChefPreference,
                DietaryRestrictions = x.RequestForQuotation.DietaryRestrictions,
                AdditionalComments = x.RequestForQuotation.AdditionalComments,
                ContactEmail = x.RequestForQuotation.ContactEmail,
                ContactPhoneNumber = x.RequestForQuotation.ContactPhoneNumber
            })
            .ToListAsync(cancellationToken);

            return new ViewModel<ReadOnlyCollection<QuotationView>>
            {
                OperationId = NewId.NextSequentialGuid(),
                Data = new ReadOnlyCollection<QuotationView>(result)
            };
        }

        private IQueryable<Quotation> ApplyFilters(IQueryable<Quotation> query, ObtainQuotationsRequest filters)
        {
            if (filters.ReservationDateFrom.HasValue)
            {
                query = query.Where(x => x.RequestForQuotation.ReservationDate >= filters.ReservationDateFrom.Value);
            }

            if (filters.ReservationDateTo.HasValue)
            {
                query = query.Where(x => x.RequestForQuotation.ReservationDate <= filters.ReservationDateTo.Value);
            }

            if (!string.IsNullOrEmpty(filters.Status))
            {
                query = query.Where(x => x.CurrentState == filters.Status);
            }

            return query;
        }

    }
}
