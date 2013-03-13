using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Nutritionix
{
    /// <summary>
    /// Nutritionix Search Response
    /// </summary>
    [JsonObject]
    public class NutritionixSearchResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public NutritionixSearchResponse()
        {
            Results = new NutritionixSearchResult[0];
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
        public double MaxScore { get; set; }

        /// <summary>
        /// A page of matching results
        /// </summary>
        [JsonProperty("hits")]
        public NutritionixSearchResult[] Results { get; set; }
    }
}