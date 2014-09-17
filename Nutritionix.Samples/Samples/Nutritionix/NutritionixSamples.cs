using Microsoft.Framework.ConfigurationModel;
using System;

namespace Nutritionix.Samples
{
    public static class NutritionixSamples
    {
        static NutritionixSamples()
        {
            // TODO: Replace with your Nutritionix API ID and Key
            var appConfig = new Configuration();
            appConfig.AddJsonFile("config.json");
            AppId = appConfig.Get("appId");
            AppKey = appConfig.Get("appKey");
        }

        private static readonly string AppId;
        private static readonly string AppKey;

        public static void RunAll()
        {
            SearchItems();
            PowerSearchItems();
            RetrieveItem();
            RetrieveItemByUPC();
            RetrieveBrand();
            RetrieveItemsByBrand();
        }

        public static void SearchItems()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(AppId, AppKey);

            var request = new SearchRequest { Query = "pie" };
			Console.WriteLine("Searching Nutritionix for 'pie'...");
            SearchResponse response = nutritionix.SearchItems(request);

			Console.WriteLine("Displaying results 1 - {0} of {1}", response.Results.Length, response.TotalResults);
            foreach(SearchResult result in response.Results)
            {
                Console.WriteLine("* {0}", result.Item.Name);
            }

			Console.WriteLine();
        }

        public static void PowerSearchItems()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(AppId, AppKey);

            var request = new PowerSearchRequest
            {
                Query = "starbucks AND frap*",
                Fields = new SearchResultFieldCollection {x => x.Name, x => x.NutritionFact_Calories, x => x.ItemType},
                SortBy = new SearchResultSort(x => x.NutritionFact_Calories, SortOrder.Descending),
                Filters = new SearchFilterCollection
                {
                    new ItemTypeFilter {Negated = true, ItemType = ItemType.Packaged}
                }
            };

            Console.WriteLine("Power Searching Nutritionix for: 'starbucks AND frap*' sorted by calories, not a packaged food...");
            SearchResponse response = nutritionix.SearchItems(request);

            Console.WriteLine("Displaying results 1 - {0} of {1}", response.Results.Length, response.TotalResults);
            foreach (SearchResult result in response.Results)
            {
                Console.WriteLine("* {0} ({1} calories) from the {2} database", result.Item.Name, result.Item.NutritionFact_Calories, result.Item.ItemType);
            }

            Console.WriteLine();
        }

        public static void RetrieveItem()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(AppId, AppKey);

            Console.WriteLine("Retrieving 'Derby Pie' by Id from Nutritionix...");
            Item item = nutritionix.RetrieveItem("51c3717897c3e69de4b0ae73");

            Console.WriteLine("Item Id: {0}", item.Id);
            Console.WriteLine("Item Name: {0}", item.Name);
            Console.WriteLine("Brand Name: {0}", item.BrandName);

            Console.WriteLine("Calories: {0}", item.NutritionFact_Calories);
            Console.WriteLine("Sugar: {0} g", item.NutritionFact_Sugar);

            Console.WriteLine();
        }

        public static void RetrieveItemByUPC()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(AppId, AppKey);

            const string upc = "029000071087";
            Console.WriteLine("Looking up UPC code: {0}...", upc);
            Item item = nutritionix.RetrieveItemByUPC(upc);

            Console.WriteLine("Item Id: {0}", item.Id);
            Console.WriteLine("Item Name: {0}", item.Name);
            Console.WriteLine("Brand Name: {0}", item.BrandName);

            Console.WriteLine("Calories: {0}", item.NutritionFact_Calories);
            Console.WriteLine("Sugar: {0} g", item.NutritionFact_Sugar);

            Console.WriteLine();
        }

        public static void RetrieveBrand()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(AppId, AppKey);

            Console.WriteLine("Retrieving 'Taco Bell' from Nutritionix...");
            Brand brand = nutritionix.RetrieveBrand("513fbc1283aa2dc80c000020");

            Console.WriteLine("Brand Id: {0}", brand.Id);
            Console.WriteLine("Brand Name: {0}", brand.Name);

            Console.WriteLine("Logo: {0}", brand.LogoUrl);
            Console.WriteLine("Website: {0}", brand.Website);

            Console.WriteLine();
        }

        public static void RetrieveItemsByBrand()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(AppId, AppKey);

            var request = new SearchRequest { BrandId = "513fbc1283aa2dc80c000024" };
            Console.WriteLine("Searching Nutritionix for the Olive Garden brand...");
            SearchResponse response = nutritionix.SearchItems(request);

            Console.WriteLine("Displaying results 1 - {0} of {1}", response.Results.Length, response.TotalResults);
            foreach (SearchResult result in response.Results)
            {
                Console.WriteLine("* {0}", result.Item.Name);
            }

            Console.WriteLine();
        }
    }
}
