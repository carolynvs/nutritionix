using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;

namespace Nutritionix.Standard.Extensions
{
    internal static class ExpressionExtensions
    {
        /// <summary>
        /// Retrieves the name of the <see cref="JsonPropertyAttribute"/> applied to the specified <see cref="Item"/> property.
        /// </summary>
        /// <param name="itemPropertyExpression">The property.</param>
        /// <returns>The JSON property name or null if none is defined.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToJsonProperty<TProperty>(this Expression<Func<Item, TProperty>> itemPropertyExpression)
        {
            var property = itemPropertyExpression.Body.GetMember();
            if (property == null)
            {
                throw new ArgumentException("The expression must represent a property on Nutritionix.Item", nameof(itemPropertyExpression));
            }

            var jsonName = property.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();

            return jsonName?.PropertyName;
        }

        public static string GetMemberName(this LambdaExpression memberExpression)
        {
            return GetMemberName(memberExpression.Body);
        }

        private static string GetMemberName(this Expression expression)
        {
            return GetMember(expression).Name;
        }

        private static MemberInfo GetMember(this Expression expression)
        {
            while (true)
            {
                var member = expression as MemberExpression;
                if (member != null)
                {
                    return member.Member;
                }

                var cast = expression as UnaryExpression;
                if (cast?.NodeType != ExpressionType.Convert)
                    throw new Exception($"The expression, {expression}, does not represent a member.");
                expression = cast.Operand;
                continue;
            }
        }
    }
}