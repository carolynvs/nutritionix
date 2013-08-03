using System.Collections.Specialized;
using System.Linq;
using Nutritionix.Extensions;

namespace Nutritionix.Uris
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

        protected override string RelativePath
        {
            get { return string.Format("search/{0}", System.Web.HttpUtility.UrlEncode(_request.Query)); }
        }

        protected override void UpdateQueryString(NameValueCollection queryString)
        {
            base.UpdateQueryString(queryString);

            if (_request.Count != null)
            {
                int start = _request.Start ?? 0;
                int stop = start + _request.Count.Value;

                queryString.Add(ResultsParam, string.Format("{0}:{1}", start, stop));
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
                queryString.Add(FieldsParam, string.Join(",", _request.Fields.GetNames()));   
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
                foreach (Allergen allergen in _request.ExcludeAllergens)
                {
                    string allergenParam = allergen.ToDescription();
                    queryString.Add(allergenParam, "false");
                }
            }
        }
    }
}