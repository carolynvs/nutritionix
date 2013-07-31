using System.ComponentModel;

// ReSharper disable CSharpWarnings::CS1591
namespace Nutritionix
{
    /// <summary>
    /// Types of food allergens
    /// </summary>
    public enum Allergen
    {
        [Description("allergen_contains_milk")]
        Milk,

        [Description("allergen_contains_eggs")]
        Eggs,
        
        [Description("allergen_contains_fish")]
        Fish,
        
        [Description("allergen_contains_shellfish")]
        Shellfish,
        
        [Description("allergen_contains_tree_nuts")]
        TreeNuts,
        
        [Description("allergen_contains_peanuts")]
        Peanuts,
        
        [Description("allergen_contains_wheat")]
        Wheat,
        
        [Description("allergen_contains_soybeans")]
        Soybeans,
        
        [Description("allergen_contains_gluten")]
        Gluten
    }
}