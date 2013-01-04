using System;
using System.Linq;
using Nutritionix;

namespace Samples.Nutritionix
{
    public static class NutritionixSamples
    {
		// TODO: Update with your Nutritionix API ID and Key
        private const string myApiId = "123";
        private const string myApiKey = "abc456";

        public static void RunAll()
        {
            Search();
			Retrieve();
            RetrieveByBrand();
        }

        public static void Search()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            var request = new NutritionixSearchRequest { Query = "pie" };
			Console.WriteLine("Searching Nutritionix for 'pie'...");
            NutritionixSearchResponse response = nutritionix.Search(request);

			Console.WriteLine("Displaying results 1 - {0} of {1}", response.TotalResultsReturned, response.TotalResultsMatching);
            foreach(NutritionixSearchResult result in response.Results)
            {
                Console.WriteLine("* {0}", result.ItemName);
            }

			Console.WriteLine();
        }

        public static void Retrieve()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            Console.WriteLine("Retrieving 'Raspberry Pie' from Nutritionix...");
            NutritionixItem item = nutritionix.Retrieve("C9eyVTt8wiSH7EhOPUBl");

            Console.WriteLine("Item Id: {0}", item.ItemId);
            Console.WriteLine("Item Name: {0}", item.ItemName);
            Console.WriteLine("Brand Name: {0}", item.BrandName);

            var calories = item.NutritionFacts.First(x => x.Name == NutritionFactType.Calories);
            Console.WriteLine("Calories: {0} {1}", calories.Value, calories.Unit);

            var sugar = item.NutritionFacts.First(x => x.Name == NutritionFactType.Sugars);
            Console.WriteLine("Sugar: {0} {1}", sugar.Value, sugar.Unit);

            Console.WriteLine();
        }

        public static void RetrieveByBrand()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            var request = new NutritionixSearchRequest { BrandId = "ONZJUDhPRs1SKbB" };
            Console.WriteLine("Searching Nutritionix for the Olive Garden brand...");
            NutritionixSearchResponse response = nutritionix.Search(request);

            Console.WriteLine("Displaying results 1 - {0} of {1}", response.TotalResultsReturned, response.TotalResultsMatching);
            foreach (NutritionixSearchResult result in response.Results)
            {
                Console.WriteLine("* {0}", result.ItemName);
            }

            Console.WriteLine();
        }
    }
}
