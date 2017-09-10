using System;
using Newtonsoft.Json;

namespace Nutritionix
{
    /// <summary>
    /// Nutritionix item, e.g. USDA food, restaurant item or packaged food
    /// </summary>
    [JsonObject]
    public class Item
    {
        /// <summary>
        /// Old API ID
        /// </summary>
        [JsonProperty("old_api_id")]
        public string OldApiId { get; set; }

        /// <summary>
        /// Item ID
        /// </summary>
        [JsonProperty("item_id")]
        public string Id { get; set; }

        /// <summary>
        /// Restaurant = 1, Packaged = 2, USDA = 3
        /// </summary>
        [JsonProperty("item_type")]
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        [JsonProperty("item_name")]
        public string Name { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("leg_loc_id")]
        public string LegLocId { get; set; }

        /// <summary>
        /// Brand ID
        /// </summary>
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        /// <summary>
        /// Name of the brand
        /// </summary>
        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        /// <summary>
        /// UPC
        /// </summary>
        [JsonProperty("upc")]
        public string UPC { get; set; }

        /// <summary>
        /// Date the item was last updated in the Nutritionix database
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Date the item was added to the Nutritionix database
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Ingredients
        /// </summary>
        [JsonProperty("nf_ingredient_statement")]
        public string IngredientStatement { get; set; }

        /// <summary>
        /// Total Calories
        /// </summary>
        [JsonProperty("nf_calories")]
        public decimal? NutritionFactCalories { get; set; }

        /// <summary>
        /// Calories from Fat (calculated)
        /// </summary>
        [JsonProperty("nf_calories_from_fat")]
        public decimal? NutritionFactCaloriesFromFat { get; set; }

        /// <summary>
        /// Total Fat
        /// </summary>
        [JsonProperty("nf_total_fat")]
        public decimal? NutritionFactTotalFat { get; set; }

        /// <summary>
        /// Saturated Fat
        /// </summary>
        [JsonProperty("nf_saturated_fat")]
        public decimal? NutritionFactSaturatedFat { get; set; }

        /// <summary>
        /// Trans Fat
        /// </summary>
        [JsonProperty("nf_trans_fatty_acid")]
        public decimal? NutritionFactTransFat { get; set; }

        /// <summary>
        /// Polyunsaturated Fat
        /// </summary>
        [JsonProperty("nf_polyunsaturated_fat")]
        public decimal? NutritionFactPolyunsaturatedFat { get; set; }

        /// <summary>
        /// Monounsaturated Fat
        /// </summary>
        [JsonProperty("nf_monounsaturated_fat")]
        public decimal? NutritionFactMonounsaturatedFat { get; set; }

        /// <summary>
        /// Cholesterol
        /// </summary>
        [JsonProperty("nf_cholesterol")]
        public decimal? NutritionFactCholesterol { get; set; }

        /// <summary>
        /// Sodium
        /// </summary>
        [JsonProperty("nf_sodium")]
        public decimal? NutritionFactSodium { get; set; }

        /// <summary>
        /// Total Carbohydrate
        /// </summary>
        [JsonProperty("nf_total_carbohydrate")]
        public decimal? NutritionFactTotalCarbohydrate { get; set; }

        /// <summary>
        /// Dietary Fiber
        /// </summary>
        [JsonProperty("nf_dietary_fiber")]
        public decimal? NutritionFactDietaryFiber { get; set; }

        /// <summary>
        /// Sugar
        /// </summary>
        [JsonProperty("nf_sugars")]
        public decimal? NutritionFactSugar { get; set; }

        /// <summary>
        /// Protein
        /// </summary>
        [JsonProperty("nf_protein")]
        public decimal? NutritionFactProtein { get; set; }

        /// <summary>
        /// Vitamin A (Daily Value %)
        /// </summary>
        [JsonProperty("nf_vitamin_a_dv")]
        public decimal? NutritionFactVitaminA { get; set; }

        /// <summary>
        /// Vitamin C (Daily Value %)
        /// </summary>
        [JsonProperty("nf_vitamin_c_dv")]
        public decimal? NutritionFactVitaminC { get; set; }

        /// <summary>
        /// Calcium (Daily Value %)
        /// </summary>
        [JsonProperty("nf_calcium_dv")]
        public decimal? NutritionFactCalcium { get; set; }

        /// <summary>
        /// Iron (Daily Value %)
        /// </summary>
        [JsonProperty("nf_iron_dv")]
        public decimal? NutritionFactIron { get; set; }

        /// <summary>
        /// Number of servings in a container
        /// </summary>
        [JsonProperty("nf_servings_per_container")]
        public decimal? NutritionFactServingsPerContainer { get; set; }

        /// <summary>
        /// Serving size quantity
        /// </summary>
        [JsonProperty("nf_serving_size_qty")]
        public decimal? NutritionFactServingSizeQuantity { get; set; }

        /// <summary>
        /// Serving size unit
        /// </summary>
        [JsonProperty("nf_serving_size_unit")]
        public string NutritionFactServingSizeUnit { get; set; }

        /// <summary>
        /// Weight of a serving in grams
        /// </summary>
        [JsonProperty("nf_serving_weight_grams")]
        public decimal? NutritionFactServingGramWeight { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Milk
        /// </summary>
        [JsonProperty("allergen_contains_milk")]
        public bool? AllergenContainsMilk { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Eggs
        /// </summary>
        [JsonProperty("allergen_contains_eggs")]
        public bool? AllergenContainsEggs { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Fish
        /// </summary>
        [JsonProperty("allergen_contains_fish")]
        public bool? AllergenContainsFish { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Shellfish
        /// </summary>
        [JsonProperty("allergen_contains_shellfish")]
        public bool? AllergenContainsShellfish { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Tree Nuts
        /// </summary>
        [JsonProperty("allergen_contains_tree_nuts")]
        public bool? AllergenContainsTreeNuts { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Peanuts
        /// </summary>
        [JsonProperty("allergen_contains_peanuts")]
        public bool? AllergenContainsPeanuts { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Wheat
        /// </summary>
        [JsonProperty("allergen_contains_wheat")]
        public bool? AllergenContainsWheat { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Soy
        /// </summary>
        [JsonProperty("allergen_contains_soybeans")]
        public bool? AllergenContainsSoy { get; set; }

        /// <summary>
        /// Flag specifying if the item is known to contain the allergen: Gluten
        /// </summary>
        [JsonProperty("allergen_contains_gluten")]
        public bool? AllergenContainsGluten { get; set; }
    }
}