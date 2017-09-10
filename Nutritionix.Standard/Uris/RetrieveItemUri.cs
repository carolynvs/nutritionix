using System.Collections.Specialized;
using Nutritionix.Standard.Extensions;

namespace Nutritionix.Standard.Uris
{
    /// <summary>
    /// Builds a URI to retrieve an item from Nutritionix
    /// </summary>
    internal class RetrieveItemUri : NutritionixUri
    {
        public RetrieveItemUri(string appId, string appKey, string id = null, string upc = null) : base(appId, appKey)
        {
            _id = id;
            _upc = upc;
        }

        private readonly string _id;
        private readonly string _upc;

        protected override string RelativePath => "item";

        protected override void UpdateQueryString(NameValueCollection queryString)
        {
            base.UpdateQueryString(queryString);

            if (!_id.IsNullOrEmpty())
            {
                queryString.Add("id", _id);
            }

            if (!_upc.IsNullOrEmpty())
            {
                queryString.Add("upc", _upc);
            }
        }
    }
}