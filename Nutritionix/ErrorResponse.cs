using Newtonsoft.Json;

namespace Nutritionix
{
    [JsonObject]
    internal class ErrorResponse
    {
        [JsonProperty("error")]
        public Error[] Errors { get; set; }
    }
}