using ChefReservationsMs.Features.Quotations.StateMachines.Events;
using ChefReservationsMs.Features.Quotations.StateMachines.Instances;
using ChefReservationsMs.Features.Quotations.StateMachines.Responses;
using MassTransit;

namespace ChefReservationsMs.Features.Quotations.StateMachines
{
    public class QuotationStateMachine : MassTransitStateMachine<Quotation>
    {
        public QuotationStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => QuotationStarted, e =>
                  e.CorrelateBy((saga, context) => saga.RequestForQuotationId == context.Message.RequestForQuotationId && saga.ChefId == context.Message.ChefId)
                  .SelectId(x => x.CorrelationId ?? NewId.NextSequentialGuid()));

            Event(() => QuotationRejected, 
                e => e.CorrelateBy((saga, context) => saga.RequestForQuotationId == context.Message.RequestForQuotationId)
                      .SelectId(x => x.CorrelationId ?? NewId.NextSequentialGuid()));

            Initially(
                When(QuotationStarted)
                    .Then(context =>
                    {
                        context.Saga.CreatedAt = InVar.Timestamp;
                        context.Saga.CreatedBy = context.Message.RequestedBy;
                        context.Saga.RequestForQuotationId = context.Message.RequestForQuotationId;
                        context.Saga.ChefId = context.Message.ChefId;
                    })
                    .TransitionTo(Opened)
                    .PublishAsync(context => context.Init<QuotationRequestArrived>(new
                    {
                        QuotationId = context.Saga.CorrelationId,
                        context.Saga.RequestForQuotation.Name,
                        context.Saga.RequestForQuotation.MealType,
                        context.Saga.RequestForQuotation.NumberOfPeople,
                        context.Saga.RequestForQuotation.CuisinePreference,
                        context.Saga.RequestForQuotation.Location,
                        context.Saga.RequestForQuotation.ReservationDate,
                        context.Saga.RequestForQuotation.StoveType,
                        context.Saga.RequestForQuotation.NumberOfBurners,
                        context.Saga.RequestForQuotation.HasWorkingOven,
                        context.Saga.RequestForQuotation.ChefPreference,
                        context.Saga.RequestForQuotation.DietaryRestrictions,
                        context.Saga.RequestForQuotation.AdditionalComments,
                        context.Saga.RequestForQuotation.ContactEmail
                    })));

            During(Opened,
                When(QuotationQuoted)
                    .Then(context =>
                    {
                        context.Saga.UpdatedAt = InVar.Timestamp;
                        context.Saga.UpdatedBy = context.Message.QuotedBy;
                        context.Saga.Price = context.Message.Price;
                        context.Saga.ChefName = context.Message.ChefName;
                        context.Saga.ChefComments = context.Message.ChefComments;
                    })
                    .TransitionTo(Quoted)
                    .PublishAsync(context => context.Init<QuotationQuotedByChef>(new QuotationQuotedByChef
                    (
                        context.Saga.CorrelationId,
                        context.Saga.ChefName ?? string.Empty,
                        context.Saga.Price,
                        context.Saga.ChefComments,
                        context.Saga.RequestForQuotation.ContactEmail
                    ))));

            During(Quoted,
                When(QuotationAccepted)
                    .Then(context =>
                    {
                        context.Saga.UpdatedAt = InVar.Timestamp;
                    })
                    .TransitionTo(Accepted)
                    .PublishAsync(context => context.Init<QuotationSuccesfullyAccepted>(new QuotationSuccesfullyAccepted
                    {
                        RequestForQuotationId = context.Saga.RequestForQuotationId
                    }))
                    .PublishAsync(context => context.Init<QuotationRejected>(new QuotationRejected
                    {
                        RequestForQuotationId = context.Saga.RequestForQuotationId
                    })),
                 When(QuotationRejected)
                    .Then(context =>
                    {
                        context.Saga.UpdatedAt = InVar.Timestamp;
                    })
                    .TransitionTo(Rejected));
        }

        public State Opened { get; }
        public State Quoted { get; }
        public State Accepted { get; }
        public State Reserved { get; }
        public State Rejected { get; }
        public State Cancelled { get; }

        public Event<QuotationStarted> QuotationStarted { get; }
        public Event<QuotationQuoted> QuotationQuoted { get; }
        public Event<QuotationAccepted> QuotationAccepted { get; }
        public Event<QuotationRejected> QuotationRejected { get; }
    }
}
