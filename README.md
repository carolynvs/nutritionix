# Nutritionix Client Library for .NET
===========

[![API Testing](https://img.shields.io/badge/API%20Test-RapidAPI-blue.svg)](https://rapidapi.com/package/Nutritionix/functions?utm_source=NutritionixGithub&utm_medium=button&utm_content=Vender_GitHub)

This is a .NET client for the [Nutritionix](http://www.nutritionix.com/) API. It is also available as a NuGet package.

[Nutritionix NuGet Package](https://nuget.org/packages/Nutritionix)  
[Nutritionix.Sample NuGet Package](https://nuget.org/packages/Nutritionix.Sample)

## Use
```csharp
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
            NutritionixSearchResponse response = nutritionix.SearchItems(request);

            return response.Results;
        }

        public NutritionixItem Retrieve(string id)
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            return nutritionix.RetrieveItem(id);
        }
    }
}
```
