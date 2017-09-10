using System.Collections.Specialized;
using System.Linq;
using System.Net;
using Nutritionix.Standard.Extensions;

namespace Nutritionix.Standard.Uris
{
    /// <summary>
    /// Builds a URI to search the items in Nutritionix
    /// </summary>
    internal class SearchUri : NutritionixUri
    {
        private const string BrandIdParam = "brand_id";
        private const string ResultsParam = "results";
        private const string FieldsParam = "fields";
        private const string MinCaloriesParam = "cal_min";
        private const string MaxCaloriesParam = "cal_max";

        private readonly SearchRequest _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchUri" /> class.
        /// </summary>
        /// <param name="appId">Your application id</param>
        /// <param name="appKey">Your application key</param>
        /// <param name="request">The search request</param>
        public SearchUri(string appId, string appKey, SearchRequest request) : base(appId, appKey)
        {
            _request = request;
        }

        protected override string RelativePath => $"search/{WebUtility.UrlEncode(_request.Query)}";

        protected override void UpdateQueryString(NameValueCollection queryString)
        {
            base.UpdateQueryString(queryString);

            if (_request.Count != null)
            {
                var start = _request.Start ?? 0;
                var stop = start + _request.Count.Value;

                queryString.Add(ResultsParam, $"{start}:{stop}");
            }

            if(_request.BrandId != null)
            {
                queryString.Add(BrandIdParam, _request.BrandId);
            }

            if(_request.IncludeAllFields)
            {
                queryString.Add(FieldsParam, "*");
            }
            else if(_request.Fields != null && _request.Fields.Any())
            {
                queryString.Add(FieldsParam, string.Join(",", _request.Fields));   
            }

            if(_request.MinimumCalories != null)
            {
                queryString.Add(MinCaloriesParam, _request.MinimumCalories.ToString());
            }

            if (_request.MaximumCalories != null)
            {
                queryString.Add(MaxCaloriesParam, _request.MinimumCalories.ToString());
            }

            if (_request.ExcludeAllergens != null)
            {
                foreach (var allergen in _request.ExcludeAllergens)
                {
                    var allergenParam = allergen.ToDescription();
                    queryString.Add(allergenParam, "false");
                }
            }
        }
    }
}