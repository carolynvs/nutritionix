using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class SearchResultFieldCollectionFixture
    {
        [Test]
        public void Initialize()
        {
            var fields = new SearchResultFieldCollection
            {
                x => x.Id
            };

            CollectionAssert.Contains(fields, "item_id");
        }

        [Test]
        public void Add()
        {
            var fields = new SearchResultFieldCollection();

            fields.Add(x => x.Name);

            CollectionAssert.Contains(fields, "item_name");
        }
    }
}