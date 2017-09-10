namespace Nutritionix.Standard.Uris
{
    internal class RetrieveBrandUri : NutritionixUri
    {
        public RetrieveBrandUri(string appId, string appKey, string id)
            : base(appId, appKey)
        {
            _id = id;
        }

        private readonly string _id;

        protected override string RelativePath => $"brand/{_id}";
    }
}