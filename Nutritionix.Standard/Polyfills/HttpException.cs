using System;

namespace Nutritionix.Standard.Polyfills
{
    public class HttpException : Exception
    {
        private int _httpCode;

        public HttpException(int httpCode, string message)
            : base(message)
        {
            _httpCode = httpCode;
        }
    }
}
