using System.Collections.Specialized;

namespace Nutritionix
{
    /// <summary>
    /// Builds a URI to search the items in Nutritionix
    /// </summary>
    public class SearchUri : NutritionixUri
    {
        private const string QueryParam = "query";
        private const string BrandIdParam = "brand_id";
        private const string StartParam = "start";
        private const string CountParam = "count";

        private readonly NutritionixSearchRequest _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchUri" /> class.
        /// </summary>
        /// <param name="appId">Your application id</param>
        /// <param name="appKey">Your application key</param>
        /// <param name="request">The search request</param>
        public SearchUri(string appId, string appKey, NutritionixSearchRequest request) : base(appId, appKey)
        {
            _request = request;
        }

        protected override string RelativePath
        {
            get { return string.Empty; }
        }

        protected override void UpdateQueryString(NameValueCollection queryString)
        {
            base.UpdateQueryString(queryString);
            queryString.Add(QueryParam, _request.Query);
            queryString.Add(BrandIdParam, _request.BrandId);
            queryString.Add(StartParam, _request.Start.ToString());
            queryString.Add(CountParam, _request.Count.ToString());
        }
    }
}