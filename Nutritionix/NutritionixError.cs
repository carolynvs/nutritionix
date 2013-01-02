using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class NutritionixError
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}