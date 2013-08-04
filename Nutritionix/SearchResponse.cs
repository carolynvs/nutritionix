using Newtonsoft.Json;

namespace Nutritionix
{
    /// <summary>
    /// Nutritionix Search Response
    /// </summary>
    [JsonObject]
    public class SearchResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchResponse()
        {
            Results = new SearchResult[0];
        }

        /// <summary>
        /// The total number of matching results
        /// </summary>
        [JsonProperty("total_hits")]
        public int TotalResults { get; set; }

        /// <summary>
        /// The highest score in the results
        /// </summary>
        [JsonProperty("max_score")]
        public double? MaxScore { get; set; }

        /// <summary>
        /// A page of matching results
        /// </summary>
        [JsonProperty("hits")]
        public SearchResult[] Results { get; set; }
    }
}