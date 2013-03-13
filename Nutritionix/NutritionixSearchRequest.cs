using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nutritionix
{
    /// <summary>
    /// Request object for searching Nutritionix
    /// </summary>
    public class NutritionixSearchRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public NutritionixSearchRequest()
        {
            Fields = new NutritionixSearchResultFieldCollection
                {
                    x => x.Id,
                    x => x.Name,
                    x => x.BrandId,
                    x => x.BrandName,
                };
        }

        /// <summary>
        /// A search term
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// A brand ID
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// Number of results to return
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// The index of the first result to return. Allows for paging the results.
        /// </summary>
        public int? Start { get; set; }

        /// <summary>
        /// List of properties that should be populated on the results
        /// <example>Fields.Add(x => x.Calories)</example>
        /// </summary>
        public NutritionixSearchResultFieldCollection Fields { get; set; }

        /// <summary>
        /// Include all available fields 
        /// </summary>
        public bool IncludeAllFields { get; set; }

        /// <summary>
        /// Only return items with at least this many calories
        /// </summary>
        public int? MinimumCalories { get; set; }

        /// <summary>
        /// Only return items with at most this many calories
        /// </summary>
        public int? MaximumCalories { get; set; }
    }

    /// <summary>
    /// Collection of <see cref="NutritionixSearchResult"/> properties that should be populated in a search's results
    /// </summary>
    public class NutritionixSearchResultFieldCollection : List<Expression<Func<NutritionixItem, object>>>
    {
        /// <summary>
        /// Returns the json properties represented by the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetNames()
        {
            foreach(Expression<Func<NutritionixItem, object>> field in this)
            {
                var propertyExpression = field.Body as MemberExpression;
                if(propertyExpression == null)
                    continue;

                var jsonName = propertyExpression.Member.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();
                if(jsonName == null)
                    continue;

                yield return jsonName.PropertyName;
            }
        }
    }
}