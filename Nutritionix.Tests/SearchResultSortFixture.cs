using Xunit;

namespace Nutritionix.Tests
{
    public class SearchResultSortFixture
    {
        [Fact]
        public void Initialize()
        {
            var sort = new SearchResultSort(x => x.NutritionFact_Calories, SortOrder.Descending);

            Assert.Equal("nf_calories", sort.Field);
            Assert.Equal("desc", sort.Order);
        }
    }
}
