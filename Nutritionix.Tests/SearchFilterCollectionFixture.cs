using Newtonsoft.Json;
using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class SearchFilterCollectionFixture
    {
        [Test]
        public void Serialize_ItemTypeFilter()
        {
            var filters = new SearchFilterCollection
            {
                new ItemTypeFilter{ItemType = ItemType.Restaurant}
            };

            var json = JsonConvert.SerializeObject(filters);
            StringAssert.Contains("{\"item_type\":1}", json);

        }

        [Test]
        public void Serialize_NotItemTypeFilter()
        {
            var filters = new SearchFilterCollection
            {
                new ItemTypeFilter{ItemType = ItemType.USDA, Negated = true}
            };

            var json = JsonConvert.SerializeObject(filters);
            StringAssert.Contains("{\"not\":{\"item_type\":3}}", json);

        }

        [Test]
        public void Serialize_RangeFilter()
        {
            var filters = new SearchFilterCollection
            {
                new RangeFilter(x => x.NutritionFactCalories){ From = 100, To = 200}
            };

            var json = JsonConvert.SerializeObject(filters);
            StringAssert.Contains("{\"nf_calories\":{\"from\":100.0,\"to\":200.0}}", json);
        }

        [Test]
        [TestCase(ComparisonOperator.GreaterThan, "{\"nf_calories\":{\"gt\":100}}")]
        [TestCase(ComparisonOperator.LessThan, "{\"nf_calories\":{\"lt\":100}}")]
        [TestCase(ComparisonOperator.GreaterThanOrEqualTo, "{\"nf_calories\":{\"gte\":100}}")]
        [TestCase(ComparisonOperator.LessThanOrEqualTo, "{\"nf_calories\":{\"lte\":100}}")]
        public void Serialize_ComparisonFilter(ComparisonOperator op, string expectedJson)
        {
            var filters = new SearchFilterCollection
            {
                new ComparisonFilter(x => x.NutritionFactCalories){Operator = op, Value = 100}
            };

            var json = JsonConvert.SerializeObject(filters);
            StringAssert.Contains(expectedJson, json);
        }
    }
}
