using System.ComponentModel;
using System.Reflection;

namespace ChefReservationsMs.Common_Services.Utils
{
    public static class EnumExtensions
    {
        public static string Description<T>(this T t) where T : notnull
        {
            if (t is null)
                throw new ArgumentNullException(nameof(t));

            var enumField = t.GetType().GetField(t!.ToString());

            var descriptionAttribute = Attribute.GetCustomAttribute(enumField, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return descriptionAttribute?.Description ?? "";
        }
    }
}
