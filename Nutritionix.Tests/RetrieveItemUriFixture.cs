using Nutritionix.Uris;
using Xunit;

namespace Nutritionix.Tests
{
    public class RetrieveItemUriFixture
    {
        [Fact]
        public void ToString_ContainsAppId()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            
            string result = uri.ToString();

            Assert.Contains("appId=myId", result);
        }

        [Fact]
        public void ToString_ContainsAppKey()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            
            string result = uri.ToString();

            Assert.Contains("appKey=myKey", result);
        }

        [Fact]
        public void ToString_ContainsItemId()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            
            string result = uri.ToString();

            Assert.Contains("id=itemId", result);
        }

        [Fact]
        public void ToString_ContainsUPC()
        {
            var uri = new RetrieveItemUri("myId", "myKey", upc: "myUPC");
            
            string result = uri.ToString();

            Assert.Contains("upc=myUPC", result);
        }
    }
}