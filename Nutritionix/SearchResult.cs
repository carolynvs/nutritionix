using Newtonsoft.Json;

namespace Nutritionix
{
    /// <summary>
    /// Result returned from a Nutritionix search
    /// </summary>
    [JsonObject]
    public class SearchResult
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
        [JsonIgnore]
        public Item Item
        {
            get
            {
                if(_item == null)
                    return _source ?? _fields;

                return _item;
            }
            set { _item = value; }
        }

        [JsonIgnore]
        private Item _item;

        [JsonProperty("fields")]
        private Item _fields;

        [JsonProperty("_source")]
        private Item _source;
    }
}