using System.Collections.Specialized;
using System.Web;
using Nutritionix.Extensions;

namespace Nutritionix.Uris
{
    /// <summary>
    /// Base class for building URIs for the Nutritionix API
    /// </summary>
    internal abstract class NutritionixUri
    {
        private const string AppIdParam = "appId";
        private const string AppKeyParam = "appKey";
        private const string RootPath = "http://api.nutritionix.com/v1_1/";

        private readonly string _appId;
        private readonly string _appKey;

        protected NutritionixUri(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
        }

        protected abstract string RelativePath { get; }

        private NameValueCollection BuildQueryString()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            UpdateQueryString(queryString);

            RemoveEmptyQueryStringParameters(queryString);

            queryString.Add(AppIdParam, _appId);
            queryString.Add(AppKeyParam, _appKey);

            return queryString;
        }

        private static void RemoveEmptyQueryStringParameters(NameValueCollection queryString)
        {
            for(int i = queryString.Count-1; i >= 0; i--)
            {
                string key = queryString.GetKey(i);
                string value = queryString[key];
                if(value.IsNullOrEmpty())
                {
                    queryString.Remove(key);
                }
            }
        }

        protected virtual void UpdateQueryString(NameValueCollection queryString)
        {
            
        }

        public override string ToString()
        {
            var queryString = BuildQueryString();
            return string.Format("{0}{1}?{2}", RootPath, RelativePath, queryString);
        }
    }
}