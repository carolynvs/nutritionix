namespace Nutritionix.Uris
{
    /// <summary>
    /// Builds a URI to retrieve an item from Nutritionix
    /// </summary>
    internal class RetrieveItemUri : NutritionixUri
    {
        public RetrieveItemUri(string appId, string appKey, string id) : base(appId, appKey)
        {
            _id = id;
        }

        private readonly string _id;

        protected override string RelativePath
        {
            get { return string.Format("item/{0}", _id); }
        }
    }
}