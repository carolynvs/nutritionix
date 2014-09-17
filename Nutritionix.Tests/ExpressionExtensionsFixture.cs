using System;
using System.Linq.Expressions;
using Nutritionix.Extensions;
using Xunit;

namespace Nutritionix.Tests
{
    public class ExpressionExtensionsFixture
    {
        [Fact]
        public void GetJsonProperty_ForStringProperty()
        {
            Expression<Func<Item, string>> property = x => x.Name;
            string jsonProperty = property.ToJsonProperty();

            Assert.Equal("item_name", jsonProperty);
        }

        [Fact]
        public void GetJsonProperty_ForNullableProperty()
        {
            Expression<Func<Item, decimal?>> property = x => x.NutritionFact_Calories;
            string jsonProperty = property.ToJsonProperty();

            Assert.Equal("nf_calories", jsonProperty);
        }
    }
}
