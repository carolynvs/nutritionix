using NUnit.Framework;
using Nutritionix.Uris;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class RetrieveItemUriFixture
    {
        [Test]
        public void ToString_ContainsAppId()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            
            string result = uri.ToString();

            StringAssert.Contains("appId=myId", result);
        }

        [Test]
        public void ToString_ContainsAppKey()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            
            string result = uri.ToString();

            StringAssert.Contains("appKey=myKey", result);
        }

        [Test]
        public void ToString_ContainsItemId()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            
            string result = uri.ToString();

            StringAssert.Contains("id=itemId", result);
        }

        [Test]
        public void ToString_ContainsUPC()
        {
            var uri = new RetrieveItemUri("myId", "myKey", upc: "myUPC");
            
            string result = uri.ToString();

            StringAssert.Contains("upc=myUPC", result);
        }
    }
}