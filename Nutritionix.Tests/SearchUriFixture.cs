using System;
using System.Collections.Generic;
using Nutritionix.Uris;
using Xunit;

namespace Nutritionix.Tests
{
    public class SearchUriFixture
    {
        [Fact]
        public void ToString_ContainsQuery()
        {
            var request = new SearchRequest {Query = "myQuery"};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            Assert.Contains("/myQuery?", result);
        }

        [Fact]
        public void ToString_ContainsBrandId()
        {
            var request = new SearchRequest { BrandId = "myBrandId"};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            Assert.Contains("brand_id=myBrandId", result);
        }

        [Fact]
        public void ToString_ContainsCount()
        {
            var request = new SearchRequest {Query = "myQuery", Count = 20};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();
            result = Uri.UnescapeDataString(result);

            Assert.Contains("results=0:20", result);
        }

        [Fact]
        public void ToString_ContainsStart()
        {
            var request = new SearchRequest { Query = "myQuery", Start = 100, Count = 50};
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();
            result = Uri.UnescapeDataString(result);

            Assert.Contains("results=100:150", result);
        }

        [Fact]
        public void ToString_DoesNotContainEmptyParameters()
        {
            var request = new SearchRequest { Query = "myQuery" };
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            // Result range should not be in the URI since no explicit value was specified
            Assert.DoesNotContain("results=", result);
        }

        [Fact]
        public void ToString_ContainsExcludedAllergens()
        {
            var request = new SearchRequest
            {
                Query = "myQuery",
                ExcludeAllergens = new List<Allergen> {Allergen.Eggs, Allergen.Fish}
            };
            var uri = new SearchUri("myId", "myKey", request);
            
            string result = uri.ToString();

            Assert.Contains("allergen_contains_eggs", result);
            Assert.Contains("allergen_contains_fish", result);
        }
    }
}