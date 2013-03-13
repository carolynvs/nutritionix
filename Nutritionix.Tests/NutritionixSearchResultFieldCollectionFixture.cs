using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class NutritionixSearchResultFieldCollectionFixture
    {
        [Test]
        public void GetNames()
        {
            var fields = new NutritionixSearchResultFieldCollection
                {
                    x => x.Id
                };

            var result = fields.GetNames();
            Assert.AreEqual(new[] {"item_id"}, result);
        }
    }
}