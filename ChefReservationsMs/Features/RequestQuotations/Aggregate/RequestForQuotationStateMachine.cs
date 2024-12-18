﻿using ChefReservationsMs.Features.RequestQuotations.Aggregate.Events;
using ChefReservationsMs.Features.RequestQuotations.Aggregate.Responses;
using MassTransit;

namespace ChefReservationsMs.Features.RequestQuotations.Aggregate
{
    public class RequestForQuotationStateMachine : MassTransitStateMachine<RequestForQuotation>
    {
        public RequestForQuotationStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Initially(
                When(ClientRequestReceived)
                .Then(context =>
                {
                    context.Saga.Name = context.Message.Name;
                    context.Saga.AdditionalComments = context.Message.AdditionalComments;
                    context.Saga.CreatedAt = InVar.Timestamp;
                    context.Saga.ChefPreference = context.Message.ChefPreference;
                    context.Saga.ContactEmail = context.Message.ContactEmail;
                    context.Saga.ContactPhoneNumber = context.Message.ContactPhoneNumber;
                    context.Saga.CuisinePreferences = context.Message.CuisinePreferences;
                    context.Saga.DietaryRestrictions = context.Message.DietaryRestrictions;
                    context.Saga.HasWorkingOven = context.Message.HasWorkingOven;
                    context.Saga.Location = context.Message.Location;
                    context.Saga.MealType = context.Message.MealType;
                    context.Saga.CreatedBy = context.Message.ContactEmail;
                    context.Saga.NumberOfBurners = context.Message.NumberOfBurners;
                    context.Saga.NumberOfPeople = context.Message.NumberOfPeople;
                    context.Saga.ReservationDate = new DateTimeOffset(context.Message.ReservationDate.DateTime, TimeSpan.Zero);
                    context.Saga.StoveType = context.Message.StoveType;
                })
                .TransitionTo(Requested)
                .Publish(context => new QuotationRequestArrived(context.Saga.CorrelationId,
                    context.Saga.Name,
                    context.Saga.MealType,
                    context.Saga.NumberOfPeople,
                    context.Saga.CuisinePreferences,
                    context.Saga.Location,
                    context.Saga.ReservationDate,
                    context.Saga.StoveType,
                    context.Saga.NumberOfBurners,
                    context.Saga.HasWorkingOven,
                    context.Saga.ChefPreference,
                    context.Saga.DietaryRestrictions,
                    context.Saga.AdditionalComments,
                    context.Saga.ContactEmail)));

            During(Requested,
                When(QuotationAccepted)
                .Then(context =>
                {
                    context.Saga.UpdatedAt = InVar.Timestamp;
                })
                .TransitionTo(PendingChefConfirmation));
        }

        public State Requested { get; }
        public State PendingChefConfirmation { get; }
        public State Confirmed { get; }
        public State Cancelled { get; }
        public State Expired { get; }

        public Event<ClientRequestReceived> ClientRequestReceived { get; }
        public Event<QuotationSuccesfullyAccepted> QuotationAccepted { get; }
    }
}
