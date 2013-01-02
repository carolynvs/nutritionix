namespace Nutritionix
{
    public class NutritionixSearchRequest
    {
        public NutritionixSearchRequest()
        {
            Count = 10;
            Start = 0;
        }

        public string Query { get; set; }
        public int Count { get; set; }
        public int Start { get; set; }
    }
}