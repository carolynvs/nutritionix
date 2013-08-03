using System;
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
        /// <exception cref="Nutritionix.NutritionixException"/>
        SearchResponse SearchItems(SearchRequest request);

        /// <summary>
        /// Retrieves the specified item from Nutritionix
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"></exception>
        Item RetrieveItem(string id);

        /// <summary>
        /// Retrieves the specified item from Nutritionix
        /// </summary>
        /// <param name="upc">The UPC</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"/>
        Item RetrieveItemByUPC(string upc);

        /// <summary>
        /// Retrieves the specified brand from Nutritionix
        /// </summary>
        /// <param name="id">The brand id</param>
        /// <returns>The requested brand or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"/>
        Brand RetrieveBrand(string id);
    }

    /// <summary>
    /// Client for accessing the Nutritionix API
    /// </summary>
    public class NutritionixClient : INutritionixClient
    {
        private string _appId;
        private string _appKey;

        // ReSharper disable once InconsistentNaming
        private readonly Func<HttpClient> CreateHttpClient;

        /// <summary>
        /// Create a new instance of <see cref="NutritionixClient"/>
        /// </summary>
        public NutritionixClient() : this(() => new HttpClient())
        {
            
        }

        /// <summary>
        /// Create a new instance of <see cref="NutritionixClient"/>
        /// </summary>
        public NutritionixClient(Func<HttpClient> createHttpClient)
        {
            CreateHttpClient = createHttpClient;
        }

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

        private void CheckInitialized()
        {
            if(_appId == null && _appKey == null)
            {
                throw new NutritionixException("You must call Initialize on the NutritionixClient before executing any other commands.");
            }
        }

        /// <summary>
        /// Searches Nutritionix for items matching the specified query.
        /// </summary>
        /// <param name="request">The query.</param>
        /// <returns>The search response from the Nutritionix API.</returns>
        /// <exception cref="Nutritionix.NutritionixException"/>
        public SearchResponse SearchItems(SearchRequest request)
        {
            CheckInitialized();

            var searchUri = new SearchUri(_appId, _appKey, request);
            var response = Get<SearchResponse>(searchUri);

            response.Results = response.Results ?? new SearchResult[0];

            return response;
        }

        /// <summary>
        /// Retrieves the specified item from the Nutritionix API
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"/>
        public Item RetrieveItem(string id)
        {
            CheckInitialized();

            var itemUri = new RetrieveItemUri(_appId, _appKey, id: id);
            return Get<Item>(itemUri);
        }

        /// <summary>
        /// Retrieves the specified item from the Nutritionix API
        /// </summary>
        /// <param name="upc">The UPC</param>
        /// <returns>The requested item or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"/>
        public Item RetrieveItemByUPC(string upc)
        {
            CheckInitialized();

            var itemUri = new RetrieveItemUri(_appId, _appKey, upc: upc);
            return Get<Item>(itemUri);
        }

        /// <summary>
        /// Retrieves the specified brand from the Nutritionix API
        /// </summary>
        /// <param name="id">The brand id</param>
        /// <returns>The requested brand or null</returns>
        /// <exception cref="Nutritionix.NutritionixException"/>
        public Brand RetrieveBrand(string id)
        {
            CheckInitialized();

            var itemUri = new RetrieveBrandUri(_appId, _appKey, id);
            return Get<Brand>(itemUri);
        }

        private TResult Get<TResult>(NutritionixUri uri) where TResult : new()
        {
            using(var client = CreateHttpClient())
            {
                HttpResponseMessage response = MakeRequest(uri, client);
                if(!response.IsSuccessStatusCode)
                {
                    var error = ReadResponse<ErrorResponse>(response);
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