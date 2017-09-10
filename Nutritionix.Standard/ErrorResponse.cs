using Newtonsoft.Json;

namespace Nutritionix.Standard
{
    [JsonObject]
    internal class ErrorResponse
    {
        [JsonProperty("error")]
        public Error[] Errors { get; set; }
    }
}