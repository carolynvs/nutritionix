# Nutritionix Client Library for .NET
===========

This is a client library for the [Nutritionix](http://www.nutritionix.com/) API.

## Use
```net
using Nutritionix;

namespace MyApp
{
    public class FooBar
    {
        private const string myApiId = "xxx";
        private const string myApiKey = "abc123";

        public NutritionixSearchResult[] Search(string query)
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            var request = new NutritionixSearchRequest { Query = query };
            NutritionixSearchResponse response = nutritionix.Search(request);

            return response.Results;
        }

        public NutritionixItem Retrieve(string id)
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            return nutritionix.Retrieve(id);
        }
    }
}
```