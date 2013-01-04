namespace Nutritionix
{
    /// <summary>
    /// Builds a URI to retrieve an item from Nutritionix
    /// </summary>
    public class RetrieveUri : NutritionixUri
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveUri" /> class.
        /// </summary>
        /// <param name="appId">Your application id</param>
        /// <param name="appKey">Your application key</param>
        /// <param name="id">The item id</param>
        public RetrieveUri(string appId, string appKey, string id) : base(appId, appKey)
        {
            _id = id;
        }

        private readonly string _id;

        protected override string RelativePath
        {
            get { return _id; }
        }
    }
}