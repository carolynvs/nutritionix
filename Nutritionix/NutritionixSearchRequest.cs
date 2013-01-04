namespace Nutritionix
{
    /// <summary>
    /// Request object for searching Nutritionix
    /// </summary>
    public class NutritionixSearchRequest
    {
        /// <summary>
        /// A search term
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// A brand ID
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// Number of results to return
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// The index of the first result to return. Allows for paging the results.
        /// </summary>
        public int? Start { get; set; }
    }
}