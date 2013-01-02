namespace Nutritionix
{
    public interface INutritionixClient
    {
        void Initialize(string appId, string appKey);
        NutritionixSearchResponse Search(NutritionixSearchRequest request);
        NutritionixItem Retrieve(string id);
    }
}