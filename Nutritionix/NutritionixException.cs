using System;

namespace Nutritionix
{
    /// <summary>
    /// Thrown when the Nutritionix Client encounters any issue querying the Nutritionix API
    /// <example>Unable to connect, json parse errors, 404 response, etc</example>
    /// </summary>
    public class NutritionixException : Exception
    {
        public NutritionixException(string message) : base(message)
        {
            
        }

        public NutritionixException(NutritionixErrorResponse response) : base("The Nutritionix API returned an error response.")
        {
            if(response != null)
            {
                Errors = response.Errors;
            }
        }

        public NutritionixError[] Errors { get; set; }
    }
}