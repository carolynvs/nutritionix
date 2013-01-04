using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class SearchUriFixture
    {
        [Test]
        public void ToString_ContainsQuery()
        {
            var request = new NutritionixSearchRequest {Query = "myQuery"};
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("query=myQuery"));
        }

        [Test]
        public void ToString_ContainsBrandId()
        {
            var request = new NutritionixSearchRequest { BrandId = "myBrandId" };
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("brand_id=myBrandId"));
        }

        [Test]
        public void ToString_ContainsStart()
        {
            var request = new NutritionixSearchRequest {Query = "myQuery", Start = 5};
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("start=5"));
        }

        [Test]
        public void ToString_ContainsCount()
        {
            var request = new NutritionixSearchRequest {Query = "myQuery", Count = 20};
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("count=20"));
        }

        [Test]
        public void ToString_DoesNotContainEmptyParameters()
        {
            var request = new NutritionixSearchRequest { Query = "myQuery" };
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsFalse(result.Contains("start="), "Start should not be in the URI since no explicit value was specified.");
            Assert.IsFalse(result.Contains("count="), "Count should not be in the URI since no explicit value was specified.");
        }
    }
}