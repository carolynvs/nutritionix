using System.Net.Http;
using Newtonsoft.Json;
using Nutritionix.Uris;

namespace Nutritionix
{
    /// <summary>
    /// Client interface for accessing the Nutritionix API
    /// </summary>
    public interface INutritionixClient
    {
        /// <summary>
        /// Sets the credentials to be used when querying the Nutritionix API.  Must be called before making any requests.
        /// </summary>
        /// <param name="appId">Your developer application id</param>
        /// <param name="appKey">Your developer application key</param>
        void Initialize(string appId, string appKey);

        /// <summary>
        /// Searches Nutritionix for items matching the specified query.
        /// </summary>
        /// <param name="request">The query.</param>
        /// <returns>The search response from the Nutritionix API.</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        NutritionixSearchResponse SearchItems(NutritionixSearchRequest request);

        /// <summary>
        /// Retrieves the specified item from Nutritionix
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        NutritionixItem RetrieveItem(string id);

        /// <summary>
        /// Retrieves the specified brand from Nutritionix
        /// </summary>
        /// <param name="id">The brand id</param>
        /// <returns>The requested brand or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        NutritionixBrand RetrieveBrand(string id);
    }

    /// <summary>
    /// Client for accessing the Nutritionix API
    /// </summary>
    public class NutritionixClient : INutritionixClient
    {
        private string _appId;
        private string _appKey;

        /// <summary>
        /// Sets the credentials to be used when querying the Nutritionix API.  Must be called before making any requests.
        /// </summary>
        /// <param name="appId">Your developer application id</param>
        /// <param name="appKey">Your developer application key</param>
        public void Initialize(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
        }

        /// <summary>
        /// Searches Nutritionix for items matching the specified query.
        /// </summary>
        /// <param name="request">The query.</param>
        /// <returns>The search response from the Nutritionix API.</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        public NutritionixSearchResponse SearchItems(NutritionixSearchRequest request)
        {
            var searchUri = new SearchUri(_appId, _appKey, request);
            var response = Get<NutritionixSearchResponse>(searchUri);

            response.Results = response.Results ?? new NutritionixSearchResult[0];

            return response;
        }

        /// <summary>
        /// Retrieves the specified item from the Nutritionix API
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        public NutritionixItem RetrieveItem(string id)
        {
            var itemUri = new RetrieveItemUri(_appId, _appKey, id);
            return Get<NutritionixItem>(itemUri);
        }

        /// <summary>
        /// Retrieves the specified brand from the Nutritionix API
        /// </summary>
        /// <param name="id">The brand id</param>
        /// <returns>The requested brand or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        public NutritionixBrand RetrieveBrand(string id)
        {
            var itemUri = new RetrieveBrandUri(_appId, _appKey, id);
            return Get<NutritionixBrand>(itemUri);
        }

        private static TResult Get<TResult>(NutritionixUri uri) where TResult : new()
        {
            using(var client = Factory.CreateHttpClient())
            {
                HttpResponseMessage response = MakeRequest(uri, client);
                if(!response.IsSuccessStatusCode)
                {
                    var error = ReadResponse<NutritionixErrorResponse>(response);
                    throw new NutritionixException(error);
                }

                return ReadResponse<TResult>(response);
            }
        }

        private static HttpResponseMessage MakeRequest(NutritionixUri uri, HttpClient client)
        {
            try
            {
                return client.GetAsync(uri.ToString()).Result;
            }
            catch
            {
                string error = string.Format("An error occurred sending a request to the Nutritionix API. Uri: {0}", uri);
                throw new NutritionixException(error);
            }
        }

        private static TResult ReadResponse<TResult>(HttpResponseMessage response) where TResult : new()
        {
            try
            {
                string content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResult>(content);
            }
            catch
            {
                throw new NutritionixException("The response returned from the Nutritionix API contained invalid JSON.");
            }
        }
    }
}