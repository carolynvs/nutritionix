using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Nutritionix.Extensions;

namespace Nutritionix
{
    /// <summary>
    /// Request object for performing a power search against Nutritionix
    /// </summary>
    [JsonObject]
    public class PowerSearchRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public PowerSearchRequest()
        {
            Fields = new SearchResultFieldCollection
            {
                x => x.Id,
                x => x.Name,
                x => x.BrandId,
                x => x.BrandName,
            };
        }

        [JsonProperty("appId")]
        internal string AppId { get; set; }

        [JsonProperty("appKey")]
        internal string AppKey { get; set; }

        /// <summary>
        /// A search term
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// List of properties that should be populated on the results
        /// <example>Fields.Add(x => x.Calories)</example>
        /// </summary>
        [JsonProperty("fields", Required = Required.Always)]
        public SearchResultFieldCollection Fields { get; set; }

        /// <summary>
        /// Number of results to return
        /// </summary>
        [JsonProperty("limit")]
        public int? Count { get; set; }

        /// <summary>
        /// The index of the first result to return. Allows for paging the results.
        /// </summary>
        [JsonProperty("offset")]
        public int? Start { get; set; }

        /// <summary>
        /// Do not return results with a score below this threshold.
        /// </summary>
        [JsonProperty("min_score")]
        public double? MinimumScore { get; set; }

        /// <summary>
        /// Sort the results by the specified property
        /// </summary>
        [JsonProperty("sort")]
        public SearchResultSort SortBy { get; set; }

        /// <summary>
        /// Filters applied to the search
        /// </summary>
        [JsonProperty("filters"),JsonConverter(typeof(SearchFilterCollectionConverter))]
        public SearchFilterCollection Filters { get; set; }
    }    

    /// <summary>
    /// Specifies how search results should be sorted
    /// </summary>
    [JsonObject]
    public class SearchResultSort
    {
        /// <summary>
        /// Create a new <see cref="SearchResultSort"/>. You may only sort by numeric properties.
        /// </summary>
        /// <param name="itemPropertyExpression">The numeric property by which to sort.</param>
        /// <param name="order">The sort order</param>
        public SearchResultSort(Expression<Func<Item, decimal?>> itemPropertyExpression, SortOrder order = SortOrder.Ascending)
        {
            Field = itemPropertyExpression.ToJsonProperty();
            Order = order.ToDescription();
        }

        /// <summary>
        /// The field on the search results by which the results should be sorted.
        /// </summary>
        [JsonProperty("field")]
        public readonly string Field;

        /// <summary>
        /// The desired sort order.
        /// </summary>
        [JsonProperty("order")]
        public readonly string Order;
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("asc")]
        Ascending,

        /// <summary>
        /// 
        /// </summary>
        [Description("desc")]
        Descending
    }
}