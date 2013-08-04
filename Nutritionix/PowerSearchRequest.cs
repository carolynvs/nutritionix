using Newtonsoft.Json;

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
        public double MinimumScore { get; set; }
    }    
}