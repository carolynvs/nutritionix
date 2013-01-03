namespace Nutritionix
{
    /// <summary>
    /// Client interface for accessing the Nutritionix API
    /// </summary>
    public interface INutritionixClient
    {
        /// <summary>
        /// Sets the credentials to be used when querying the Nutritionix API.  Must be called before making any requests.
        /// </summary>
        /// <param name="appId">Your developer application id</param>
        /// <param name="appKey">Your developer application key</param>
        void Initialize(string appId, string appKey);

        /// <summary>
        /// Searches Nutritionix for items matching the specified query.
        /// </summary>
        /// <param name="request">The query.</param>
        /// <returns>The search response from the Nutritionix API.</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        NutritionixSearchResponse Search(NutritionixSearchRequest request);

        /// <summary>
        /// Retrieves the specified item from Nutritionix
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        NutritionixItem Retrieve(string id);
    }
}