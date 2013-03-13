using System;

namespace Nutritionix
{
    /// <summary>
    /// Thrown when the Nutritionix Client encounters any issue querying the Nutritionix API
    /// <example>Unable to connect, json parse errors, 404 response, etc</example>
    /// </summary>
    public class NutritionixException : Exception
    {
        internal NutritionixException(string message) : base(message)
        {
            
        }

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