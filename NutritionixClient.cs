using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace Nutritionix
{
    public class NutritionixClient : INutritionixClient
    {
        private string _appId;
        private string _appKey;

        private const string _rootUrl = "http://devapi.nutritionix.com/v1/api/item/";
        private const string _queryUrl = _rootUrl + "?query={2}&appId={0}&appKey={1}";
        private const string _itemUrl = _rootUrl + "{2}?appId={0}&appKey={1}";
        
        public void Initialize(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
        }

        public NutritionixSearchResponse Search(NutritionixSearchRequest request)
        {
            using (var client = new HttpClient())
            {
                string uri = BuildUri(_queryUrl, _appId, _appKey, request.Query);
                HttpResponseMessage response = client.GetAsync(uri).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var error = ReadResponse<NutritionixErrorResponse>(response);
                    throw new NutritionixException(error);
                }

                return ReadResponse<NutritionixSearchResponse>(response);
            }
        }

        public NutritionixItem Retrieve(string id)
        {
            using (var client = new HttpClient())
            {
                string uri = BuildUri(_itemUrl, _appId, _appKey, id);
                HttpResponseMessage response = client.GetAsync(uri).Result;

                if (!response.IsSuccessStatusCode)
                {
                    var error = ReadResponse<NutritionixErrorResponse>(response);
                    throw new NutritionixException(error);
                }

                return ReadResponse<NutritionixItem>(response);
            }
        }

        private static T ReadResponse<T>(HttpResponseMessage response)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }

        private static string BuildUri(string uri, params object[] args)
        {
            object[] escapedArgs = args.Select(x => HttpUtility.UrlEncode(x.ToString())).OfType<object>().ToArray();
            return string.Format(uri, escapedArgs);
        }
    }
}