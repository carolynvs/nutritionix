using System.Collections.Generic;

namespace Nutritionix
{
    /// <summary>
    /// Request object for searching Nutritionix
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchRequest()
        {
            Fields = new SearchResultFieldCollection
                {
                    x => x.Id,
                    x => x.Name,
                    x => x.BrandId,
                    x => x.BrandName,
                };
            ExcludeAllergens = new List<Allergen>();
        }

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

        /// <summary>
        /// List of properties that should be populated on the results
        /// <example>Fields.Add(x => x.Calories)</example>
        /// </summary>
        public SearchResultFieldCollection Fields { get; set; }

        /// <summary>
        /// List of <see cref="Allergen"/>s which should be excluded from the results
        /// </summary>
        public List<Allergen> ExcludeAllergens { get; set; }

        /// <summary>
        /// Include all available fields 
        /// </summary>
        public bool IncludeAllFields { get; set; }

        /// <summary>
        /// Only return items with at least this many calories
        /// </summary>
        public int? MinimumCalories { get; set; }

        /// <summary>
        /// Only return items with at most this many calories
        /// </summary>
        public int? MaximumCalories { get; set; }
    }
}