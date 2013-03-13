using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Nutritionix
{
    /// <summary>
    /// Result returned from a Nutritionix search
    /// </summary>
    [JsonObject]
    public class NutritionixSearchResult
    {
        /// <summary>
        /// Search result item id, equivalent to Item.ItemId
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Search result index
        /// </summary>
        [JsonProperty("_index")]
        public string Index { get; set; }

        /// <summary>
        /// Search result type
        /// </summary>
        [JsonProperty("_type")]
        public string Type { get; set; }

        /// <summary>
        /// Search score
        /// </summary>
        [JsonProperty("_score")]
        public double Score { get; set; }

        /// <summary>
        /// Matching item
        /// </summary>
        [JsonProperty("item")]
        public NutritionixItem Item
        {
            get { return _source ?? _fields; }
        }

        [JsonProperty("fields")]
        private NutritionixItem _fields;

        [JsonProperty("_source")]
        private NutritionixItem _source;
    }
}