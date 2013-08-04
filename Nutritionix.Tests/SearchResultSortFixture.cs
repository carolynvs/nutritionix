using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class SearchResultSortFixture
    {
        [Test]
        public void Initialize()
        {
            var sort = new SearchResultSort(x => x.NutritionFact_Calories, SortOrder.Descending);

            Assert.AreEqual("nf_calories", sort.Field);
            Assert.AreEqual("desc", sort.Order);
        }
    }
}
