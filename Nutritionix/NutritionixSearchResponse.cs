using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class NutritionixSearchResponse
    {
        public NutritionixSearchResponse()
        {
            Results = new NutritionixSearchResult[0];
        }

        [DataMember(Name = "total_results_matching")]
        public int TotalResultsMatching { get; set; }

        [DataMember(Name = "total_results_returned")]
        public int TotalResultsReturned { get; set; }

        [DataMember(Name = "results")]
        public NutritionixSearchResult[] Results { get; set; }
    }
}