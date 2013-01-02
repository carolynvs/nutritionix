using System.Collections.Specialized;
using System.Web;

namespace Nutritionix
{
    public abstract class NutritionixUriBase
    {
        private const string AppIdParam = "appId";
        private const string AppKeyParam = "appKey";
        private const string RootPath = "http://devapi.nutritionix.com/v1/api/item/";

        protected NutritionixUriBase(string appId, string appKey)
        {
            _queryString = HttpUtility.ParseQueryString(string.Empty);
            AddParameter(AppIdParam, appId);
            AddParameter(AppKeyParam, appKey);
        }

        private readonly NameValueCollection _queryString;

        protected void AddParameter(string parameter, object value)
        {
            if(value == null)
                return;

            _queryString[parameter] = HttpUtility.UrlEncode(value.ToString());
        }

        protected abstract string RelativePath { get; }

        public override string ToString()
        {
            return string.Format("{0}{1}?{2}", RootPath, RelativePath, _queryString);
        }
    }
}