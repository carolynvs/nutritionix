using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class Allergen
    {
        [DataMember(Name="type")]
        public string Type { get; set; }
    }
}