using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class DietaryConstraint
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}