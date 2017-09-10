using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Nutritionix.Standard.Extensions
{
    internal static class EnumExtensions
    {
        /// <summary>
        /// Retrieves the DescriptionAttribute value from an enum value.
        /// </summary>
        /// <param name="value">The enum value</param>
        /// <returns>The DescriptionAttribute value or if not defined, value.ToString()</returns>
        public static string ToDescription(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetRuntimeFields()
                    .FirstOrDefault(x => x.Name == value.ToString())
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }
    }
}
