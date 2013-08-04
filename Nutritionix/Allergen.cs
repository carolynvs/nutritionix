using System.ComponentModel;

// ReSharper disable CSharpWarnings::CS1591
namespace Nutritionix
{
    /// <summary>
    /// Types of food allergens
    /// </summary>
    public enum Allergen
    {
        /// <summary>
        /// Contains milk
        /// </summary>
        [Description("allergen_contains_milk")]
        Milk,

        /// <summary>
        /// Contains eggs
        /// </summary>
        [Description("allergen_contains_eggs")]
        Eggs,
        
        /// <summary>
        /// Contains fish
        /// </summary>
        [Description("allergen_contains_fish")]
        Fish,
        
        /// <summary>
        /// Contains shellfish
        /// </summary>
        [Description("allergen_contains_shellfish")]
        Shellfish,
        
        /// <summary>
        /// Contains tree nuts
        /// </summary>
        [Description("allergen_contains_tree_nuts")]
        TreeNuts,
        
        /// <summary>
        /// Contains peanuts
        /// </summary>
        [Description("allergen_contains_peanuts")]
        Peanuts,
        
        /// <summary>
        /// Contains wheat
        /// </summary>
        [Description("allergen_contains_wheat")]
        Wheat,
        
        /// <summary>
        /// Contains soy
        /// </summary>
        [Description("allergen_contains_soybeans")]
        Soybeans,
        
        /// <summary>
        /// Contains gluten
        /// </summary>
        [Description("allergen_contains_gluten")]
        Gluten
    }
}