using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class RetrieveUriFixture
    {
        [Test]
        public void ToString_ContainsAppId()
        {
            var uri = new RetrieveUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("appId=myId"));
        }

        [Test]
        public void ToString_ContainsAppKey()
        {
            var uri = new RetrieveUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("appKey=myKey"));
        }

        [Test]
        public void ToString_ContainsItemId()
        {
            var uri = new RetrieveUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("/itemId?"));
        }
    }
}