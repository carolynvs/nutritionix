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

        protected bool IncludeQueryString { get; set; }

        protected NutritionixUri(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
            IncludeQueryString = true;
        }

        protected abstract string RelativePath { get; }

        private QueryString BuildQueryString()
        {
            var queryString = new QueryString();
            UpdateQueryString(queryString);
            queryString.Add(AppIdParam, _appId);
            queryString.Add(AppKeyParam, _appKey);

            return queryString;
        }

        protected virtual void UpdateQueryString(QueryString queryString)
        {

        }

        public override string ToString()
        {
            if (IncludeQueryString)
            {
                var queryString = BuildQueryString();

                return string.Format("{0}{1}?{2}", RootPath, RelativePath, queryString);
            }

            return string.Format("{0}{1}", RootPath, RelativePath);
        }
    }
}