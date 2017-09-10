using System;
using Newtonsoft.Json;

namespace Nutritionix.Standard
{
    /// <summary>
    /// Nutritionix brand, representing a restaurant or manufacturer
    /// </summary>
    [JsonObject]
    public class Brand
    {
        /// <summary>
        /// Brand ID
        /// </summary>
        [JsonProperty("brand_id")]
        public string Id { get; set; }

        /// <summary>
        /// Brand Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Brand website
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// Url of the brand's logo
        /// </summary>
        [JsonIgnore]
        public string LogoUrl => $"http://res.cloudinary.com/nutritionix/image/upload/w_50,h_50,c_fit/{Id}.jpg";

        /// <summary>
        /// Brand Type
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// Date the brand was added to the Nutritionix database
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Date the brand was last updated in the Nutritionix database
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? Updated { get; set; }
    }
}