using System.Collections.Generic;
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
            
            string result = uri.ToString();

            StringAssert.Contains("/myQuery?", result);
        }

        [Test]
        public void ToString_ContainsBrandId()
        {
            var request = new NutritionixSearchRequest { BrandId = "myBrandId"};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            StringAssert.Contains("brand_id=myBrandId", result);
        }

        [Test]
        public void ToString_ContainsCount()
        {
            var request = new NutritionixSearchRequest {Query = "myQuery", Count = 20};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();
            result = HttpUtility.UrlDecode(result);

            StringAssert.Contains("results=0:20", result);
        }

        [Test]
        public void ToString_ContainsStart()
        {
            var request = new NutritionixSearchRequest { Query = "myQuery", Start = 100, Count = 50};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();
            result = HttpUtility.UrlDecode(result);

            StringAssert.Contains("results=100:150", result);
        }

        [Test]
        public void ToString_DoesNotContainEmptyParameters()
        {
            var request = new NutritionixSearchRequest { Query = "myQuery" };
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            StringAssert.DoesNotContain("results=", result, "Result range should not be in the URI since no explicit value was specified.");
        }

        [Test]
        public void ToString_ContainsExcludedAllergens()
        {
            var request = new NutritionixSearchRequest
            {
                Query = "myQuery",
                ExcludeAllergens = new List<Allergen> {Allergen.Eggs, Allergen.Fish}
            };
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            StringAssert.Contains("allergen_contains_eggs", result);
            StringAssert.Contains("allergen_contains_fish", result);
        }
    }
}