using System;

namespace Nutritionix
{
    public class NutritionixException : Exception
    {
        public NutritionixException(NutritionixErrorResponse error)
        {
            Error = error;
        }

        public NutritionixErrorResponse Error { get; set; }
    }
}