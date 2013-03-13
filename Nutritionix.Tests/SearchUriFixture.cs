using System.Web;
using NUnit.Framework;
using Nutritionix.Uris;

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

            Assert.IsTrue(result.Contains("/myQuery?"));
        }

        [Test]
        public void ToString_ContainsBrandId()
        {
            var request = new NutritionixSearchRequest { BrandId = "myBrandId"};
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("brand_id=myBrandId"));
        }

        [Test]
        public void ToString_ContainsCount()
        {
            var request = new NutritionixSearchRequest {Query = "myQuery", Count = 20};
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            result = HttpUtility.UrlDecode(result);

            Assert.IsTrue(result.Contains("results=0:20"));
        }

        [Test]
        public void ToString_ContainsStart()
        {
            var request = new NutritionixSearchRequest { Query = "myQuery", Start = 100, Count = 50};
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            result = HttpUtility.UrlDecode(result);

            Assert.IsTrue(result.Contains("results=100:150"));
        }

        [Test]
        public void ToString_DoesNotContainEmptyParameters()
        {
            var request = new NutritionixSearchRequest { Query = "myQuery" };
            var uri = new SearchUri("myId", "myKey", request);
            var result = uri.ToString();

            Assert.IsFalse(result.Contains("results="), "Result range should not be in the URI since no explicit value was specified.");
        }
    }
}