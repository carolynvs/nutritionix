using System;
using System.Net;

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
        public NutritionixException(string message, HttpStatusCode status = HttpStatusCode.InternalServerError) : base(message)
        {
            Status = status;    
        }

        /// <summary>
        /// Creates a new <see cref="NutritionixException"/> from a error response
        /// </summary>
        internal NutritionixException(ErrorResponse response)
            : base("The Nutritionix API returned an error response.")
        {
            if(response != null)
            {
                Errors = response.Errors;
            }
        }

        /// <summary>
        /// An HTTP status code representing the type of error
        /// </summary>
        public HttpStatusCode Status { get;set; }

        /// <summary>
        /// The errors returned from the Nutritionix API
        /// </summary>
        public Error[] Errors { get; set; }
    }
}