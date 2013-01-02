using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class NutritionixErrorResponse
    {
        [DataMember(Name = "error")]
        public NutritionixError[] Errors { get; set; }
    }
}