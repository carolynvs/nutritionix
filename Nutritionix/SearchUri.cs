namespace Nutritionix
{
    public class SearchUri : NutritionixUriBase
    {
        private const string QueryParam = "query";
        private const string StartParam = "start";
        private const string CountParam = "count";

        public SearchUri(string appId, string appKey, NutritionixSearchRequest request) : base(appId, appKey)
        {
            AddParameter(QueryParam, request.Query);
            AddParameter(StartParam, request.Start);
            AddParameter(CountParam, request.Count);
        }

        protected override string RelativePath
        {
            get { return string.Empty; }
        }
    }
}