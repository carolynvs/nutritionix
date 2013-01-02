namespace Nutritionix
{
    public class NutritionixSearchRequest
    {
        public string Query { get; set; }
        public int? Count { get; set; }
        public int? Start { get; set; }
    }
}