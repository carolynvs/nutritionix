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
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("appId=myId"));
        }

        [Test]
        public void ToString_ContainsAppKey()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("appKey=myKey"));
        }

        [Test]
        public void ToString_ContainsItemId()
        {
            var uri = new RetrieveItemUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("item/itemId"));
        }
    }
}