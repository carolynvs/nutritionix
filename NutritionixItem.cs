using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class NutritionixItem
    {
        [DataMember(Name = "item_id")]
        public string ItemId { get; set; }

        [DataMember(Name = "item_name")]
        public string ItemName { get; set; }

        [DataMember(Name = "brand_id")]
        public string BrandId { get; set; }

        [DataMember(Name = "brand_name")]
        public string BrandName { get; set; }

        [DataMember(Name = "upc")]
        public string UPC { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "last_updated")]
        public DateTime LastUpdated { get; set; }

        [DataMember(Name = "nutrition_facts")]
        public List<NutritionFact> NutritionFacts { get; set; }
    }
}