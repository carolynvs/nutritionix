using NUnit.Framework;
using Nutritionix.Uris;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class RetrieveBrandUriFixture
    {
        [Test]
        public void ToString_ContainsAppId()
        {
            var uri = new RetrieveBrandUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("appId=myId"));
        }

        [Test]
        public void ToString_ContainsAppKey()
        {
            var uri = new RetrieveBrandUri("myId", "myKey", "itemId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("appKey=myKey"));
        }

        [Test]
        public void ToString_ContainsBrandId()
        {
            var uri = new RetrieveBrandUri("myId", "myKey", "brandId");
            var result = uri.ToString();

            Assert.IsTrue(result.Contains("brand/brandId"));
        }
    }
}