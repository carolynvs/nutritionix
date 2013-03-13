namespace Nutritionix.Uris
{
    internal class RetrieveBrandUri : NutritionixUri
    {
        public RetrieveBrandUri(string appId, string appKey, string id)
            : base(appId, appKey)
        {
            _id = id;
        }

        private readonly string _id;

        protected override string RelativePath
        {
            get { return string.Format("brand/{0}", _id); }
        }
    }
}