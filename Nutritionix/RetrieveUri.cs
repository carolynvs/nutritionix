namespace Nutritionix
{
    public class RetrieveUri : NutritionixUriBase
    {
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