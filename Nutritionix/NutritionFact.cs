using System.Globalization;
using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class NutritionFact
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [IgnoreDataMember]
        public bool IsPercentage
        {
            get { return Unit != null && Unit.ToLower(CultureInfo.InvariantCulture) == NutritionixUnit.Percentage; }
        }
    }
}