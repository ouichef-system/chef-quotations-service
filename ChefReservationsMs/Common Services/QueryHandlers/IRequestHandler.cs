namespace ChefReservationsMs.Common_Services.QueryHandlers
{
    public interface IRequestHandler<in TRequest, TResult>
    {
        ValueTask<ViewModel<TResult>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
