using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using Nutritionix.Extensions;

namespace Nutritionix.Tests
{

    [TestFixture]
    public class ExpressionExtensionsFixture
    {
        [Test]
        public void GetJsonProperty_ForStringProperty()
        {
            Expression<Func<Item, string>> property = x => x.Name;
            string jsonProperty = property.ToJsonProperty();

            Assert.AreEqual("item_name", jsonProperty);
        }

        [Test]
        public void GetJsonProperty_ForNullableProperty()
        {
            Expression<Func<Item, decimal?>> property = x => x.NutritionFact_Calories;
            string jsonProperty = property.ToJsonProperty();

            Assert.AreEqual("nf_calories", jsonProperty);
        }
    }
}
