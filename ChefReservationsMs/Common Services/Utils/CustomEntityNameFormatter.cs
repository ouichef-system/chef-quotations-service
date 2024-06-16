using MassTransit.Internals;
using MassTransit;
using System.Text.RegularExpressions;

namespace ChefReservationsMs.Common_Services.Utils
{
    public partial class CustomEntityNameFormatter : IEntityNameFormatter
    {
        readonly IEntityNameFormatter _entityNameFormatter;

        public CustomEntityNameFormatter(IEntityNameFormatter entityNameFormatter)
        {
            _entityNameFormatter = entityNameFormatter;
        }

        public string FormatEntityName<T>()
        {
            if (typeof(T).ClosesType(typeof(CorrelatedBy<>)))
            {
                return EndPointFormat().Replace(typeof(T).Name, "-$1")
                            .Trim()
                            .ToLower();
            }

            return _entityNameFormatter.FormatEntityName<T>();
        }

        [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])", RegexOptions.Compiled)]
        private static partial Regex EndPointFormat();
    }

    public static class CustomConfigurationExtensions
    {
        /// <summary>
        /// Should be using on every UsingRabbitMq configuration
        /// </summary>
        /// <param name="configurator"></param>
        public static void SetCustomEntityNameFormatter(this IBusFactoryConfigurator configurator)
        {
            var entityNameFormatter = configurator.MessageTopology.EntityNameFormatter;

            configurator.MessageTopology.SetEntityNameFormatter(new CustomEntityNameFormatter(entityNameFormatter));
        }
    }
}
