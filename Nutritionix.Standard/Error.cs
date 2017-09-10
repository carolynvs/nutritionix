using Newtonsoft.Json;

namespace Nutritionix.Standard
{
    /// <summary>
    /// Nutritionix Error
    /// </summary>
    [JsonObject]
    public class Error
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}