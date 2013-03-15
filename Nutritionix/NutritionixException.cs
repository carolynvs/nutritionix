using System;

namespace Nutritionix
{
    /// <summary>
    /// Thrown when the Nutritionix Client encounters any issue querying the Nutritionix API
    /// <example>Unable to connect, json parse errors, 404 response, etc</example>
    /// </summary>
    public class NutritionixException : Exception
    {
        /// <summary>
        /// Create a new <see cref="NutritionixException"/> from an error message
        /// </summary>
        public NutritionixException(string message) : base(message)
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="NutritionixException"/> from a error response
        /// </summary>
        internal NutritionixException(NutritionixErrorResponse response)
            : base("The Nutritionix API returned an error response.")
        {
            if(response != null)
            {
                Errors = response.Errors;
            }
        }

        /// <summary>
        /// The errors returned from the Nutritionix API
        /// </summary>
        public NutritionixError[] Errors { get; set; }
    }
}