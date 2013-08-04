using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nutritionix.Extensions;

namespace Nutritionix
{
    /// <summary>
    /// Collection of <see cref="SearchResult"/> properties that should be populated in a search's results
    /// </summary>
    public class SearchResultFieldCollection : List<string>
    {
        /// <summary>
        /// Adds the specified field expression, converting the expression to the appropriate string reprentation.
        /// </summary>
        /// <param name="itemPropertyExpression">An expression representing the property on <see cref="Item"/> that should be included.</param>
        public void Add(Expression<Func<Item, object>> itemPropertyExpression)
        {
            string jsonProperty = itemPropertyExpression.ToJsonProperty();
            if(jsonProperty == null)
                return;

            Add(jsonProperty);
        }
    }
}