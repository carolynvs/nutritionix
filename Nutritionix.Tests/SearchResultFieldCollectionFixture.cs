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
                x => x.NutritionFactCalories
            };

            CollectionAssert.Contains(fields, "nf_calories");
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