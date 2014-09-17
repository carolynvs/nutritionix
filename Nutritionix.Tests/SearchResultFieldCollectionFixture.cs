using Xunit;

namespace Nutritionix.Tests
{
    public class SearchResultFieldCollectionFixture
    {
        [Fact]
        public void Initialize()
        {
            var fields = new SearchResultFieldCollection
            {
                x => x.NutritionFact_Calories
            };

            Assert.True(fields.Contains("nf_calories"));
        }

        [Fact]
        public void Add()
        {
            var fields = new SearchResultFieldCollection();

            fields.Add(x => x.Name);

            Assert.True(fields.Contains("item_name"));
        }
    }
}