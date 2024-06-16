using ChefReservationsMs.Common_Services.QueryHandlers;

namespace ChefReservationsMs.Common_Services.Utils
{
    public delegate ValueTask<ViewModel<TResult>> RequestHandler<in TRequest, TResult>(TRequest request, CancellationToken cancellationToken);
    public static class QueryHandlerConfig
    {
        public static IServiceCollection AddQueryHandler<TRequest, TResult, TRequestHandler>(this IServiceCollection services) where TRequestHandler : class, IRequestHandler<TRequest, TResult>
        {
            services.AddScoped<IRequestHandler<TRequest, TResult>, TRequestHandler>()
                    .AddScoped<RequestHandler<TRequest, TResult>>(x => x.GetRequiredService<IRequestHandler<TRequest, TResult>>().Handle);

            return services;
        }
    }
}
