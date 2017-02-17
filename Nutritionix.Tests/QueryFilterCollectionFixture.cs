using Newtonsoft.Json;
using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class QueryFilterCollectionFixture
    {
        [Test]
        public void Initialize()
        {
            var queryFilterCollection = new QueryFilterCollection { new QueryFilter(x => x.Name, "Food") };

            string json = JsonConvert.SerializeObject(queryFilterCollection);
            StringAssert.Contains("{\"item_name\":\"Food\"}", json);
        }
    }
}
