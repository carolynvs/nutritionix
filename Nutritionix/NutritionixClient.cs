using System.Net.Http;
using Newtonsoft.Json;

namespace Nutritionix
{
    public class NutritionixClient : INutritionixClient
    {
        private string _appId;
        private string _appKey;

        public void Initialize(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
        }

        public NutritionixSearchResponse Search(NutritionixSearchRequest request)
        {
            var searchUri = new SearchUri(_appId, _appKey, request);
            var response = Get<NutritionixSearchResponse>(searchUri);

            response.Results = response.Results ?? new NutritionixSearchResult[0];

            return response;
        }

        public NutritionixItem Retrieve(string id)
        {
            var itemUri = new RetrieveUri(_appId, _appKey, id);
            return Get<NutritionixItem>(itemUri);
        }

        private static TResult Get<TResult>(NutritionixUriBase uri)
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(uri.ToString()).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var error = ReadResponse<NutritionixErrorResponse>(response);
                    throw new NutritionixException(error);
                }

                return ReadResponse<TResult>(response);
            }
        }

        private static T ReadResponse<T>(HttpResponseMessage response)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}