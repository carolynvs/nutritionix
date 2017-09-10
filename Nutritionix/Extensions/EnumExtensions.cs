using System;
using System.ComponentModel;

namespace Nutritionix.Extensions
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
            if (value == null)
                return null;

            var attribute = GetAttribute<DescriptionAttribute>(value);
            return attribute == null ? value.ToString() : attribute.Description;
        }

        private static T GetAttribute<T>(Enum value)
            where T : class
        {
            var field = value.GetType().GetField(value.ToString());
            return Attribute.GetCustomAttribute(field, typeof (T)) as T;
        }
    }
}
