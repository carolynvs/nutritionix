using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class SearchResultFieldCollectionFixture
    {
        [Test]
        public void GetNames()
        {
            var fields = new SearchResultFieldCollection
                {
                    x => x.Id
                };

            var result = fields.GetNames();
            Assert.AreEqual(new[] {"item_id"}, result);
        }
    }
}