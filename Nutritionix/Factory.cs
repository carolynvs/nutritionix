using System.Net.Http;

namespace Nutritionix
{
    /// <summary>
    /// Factory class for creating instances of mockable dependencies
    /// </summary>
    internal static class Factory
    {
        public static HttpMessageHandler MockHttpClient;

        public static HttpClient CreateHttpClient()
        {
            if (MockHttpClient != null)
                return new HttpClient(MockHttpClient);

            return new HttpClient();
        }
    }
}