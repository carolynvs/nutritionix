using Nutritionix.Uris;
using Xunit;

namespace Nutritionix.Tests
{
    public class RetrieveBrandUriFixture
    {
        [Fact]
        public void ToString_ContainsAppId()
        {
            var uri = new RetrieveBrandUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.True(result.Contains("appId=myId"));
        }

        [Fact]
        public void ToString_ContainsAppKey()
        {
            var uri = new RetrieveBrandUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.True(result.Contains("appKey=myKey"));
        }

        [Fact]
        public void ToString_ContainsBrandId()
        {
            var uri = new RetrieveBrandUri("myId", "myKey", "brandId");
            var result = uri.ToString();

            Assert.True(result.Contains("brand/brandId"));
        }
    }
}