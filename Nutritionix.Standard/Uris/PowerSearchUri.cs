namespace Nutritionix.Standard.Uris
{
    /// <summary>
    /// Builds a URI to power search the items in Nutritionix
    /// </summary>
    internal class PowerSearchUri : NutritionixUri
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchUri" /> class.
        /// </summary>
        /// <param name="appId">Your application id</param>
        /// <param name="appKey">Your application key</param>
        public PowerSearchUri(string appId, string appKey) : base(appId, appKey)
        {
            IncludeQueryString = false;
        }

        protected override string RelativePath => "search";
    }
}