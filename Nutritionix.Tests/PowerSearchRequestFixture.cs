﻿using Newtonsoft.Json;
using NUnit.Framework;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class PowerSearchRequestFixture
    {
        [Test]
        public void Serialize_MinScore()
        {
            var request = new PowerSearchRequest {MinimumScore = 0.5};

            var json = JsonConvert.SerializeObject(request);

            StringAssert.Contains("\"min_score\":0.5", json);
        }

        [Test]
        public void Serialize_Filters()
        {
            var request = new PowerSearchRequest
            {
                Filters = new SearchFilterCollection
                {
                    new ItemTypeFilter {ItemType = ItemType.Restaurant},
                    new ComparisonFilter(x => x.NutritionFactCalories){Operator = ComparisonOperator.LessThan, Value = 100}
                }
            };

            var json = JsonConvert.SerializeObject(request);

            StringAssert.Contains("\"filters\":{\"item_type\":1,\"nf_calories\":{\"lt\":100}}", json);
        }
    }
}
