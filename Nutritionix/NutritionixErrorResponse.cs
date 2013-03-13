using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Nutritionix
{
    [JsonObject]
    internal class NutritionixErrorResponse
    {
        [JsonProperty("error")]
        public NutritionixError[] Errors { get; set; }
    }
}