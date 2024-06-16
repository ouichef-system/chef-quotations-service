using MassTransit;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ChefReservationsMs.Common_Services.QueryHandlers
{
    public record ViewModel<T>
    {
        public ViewModel([CallerFilePath] string caller = "")
        {
            OperationName = $"{Assembly.GetExecutingAssembly().GetName().Name}/{caller.Split('\\')[^1]}";
        }

        public string? OperationName { get; }
        public Guid? OperationId { get; init; } = NewId.NextGuid();
        public required T Data { get; init; }
    }
}
