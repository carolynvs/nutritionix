using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Rhino.Mocks;
using Xunit;

namespace Nutritionix.Tests
{
    public class NutritionixClientFixture
    {
        private FakeHttpMessageHandler _mockHttp;
        private NutritionixClient _nutritionix;

        public NutritionixClientFixture()
        {
            _mockHttp = MockRepository.GeneratePartialMock<FakeHttpMessageHandler>();
            _nutritionix = new NutritionixClient(() => new HttpClient(_mockHttp));
            _nutritionix.Initialize("myAppId", "myAppKey");
        }

        [Fact]
        public void Search_ReturnsEmptyResults_WhenResultsIsNull()
        {
            var sampleResponse = new SearchResponse
            {
                TotalResults = 0,
                Results = null
            };
            string json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var request = new SearchRequest {Query = "foobar"};
            SearchResponse response = _nutritionix.SearchItems(request);

            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Length);
        }

        [Fact]
        public void Search_ReturnsPopulatedResults()
        {
            var sampleResponse = new SearchResponse
            {
                TotalResults = 1,
                Results = new[] {new SearchResult()}
            };
            string json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var request = new SearchRequest {Query = "foobar"};
            SearchResponse response = _nutritionix.SearchItems(request);

            Assert.Equal(1, response.Results.Length);
        }

        [Fact]
        public void PowerSearch_ReturnsPopulatedResults()
        {
            var sampleResponse = new SearchResponse
            {
                TotalResults = 1,
                Results = new[] {new SearchResult()}
            };
            string json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var request = new PowerSearchRequest {Query = "foobar"};
            SearchResponse response = _nutritionix.SearchItems(request);

            Assert.Equal(1, response.Results.Length);
        }

        [Fact]
        public void Search_ThrowsNutritionixException_WhenResponseContainsUnparseableJson()
        {
            MockResponse("<!_foobar'd");

            var request = new SearchRequest {Query = "foobar"};

            Assert.Throws<NutritionixException>(() =>
            {
                _nutritionix.SearchItems(request);
            });
        }

        [Fact]
        public void Search_ThrowsNutritionixException_WhenBadResponseIsReturned()
        {
            MockResponse(string.Empty, HttpStatusCode.BadRequest);

            var request = new SearchRequest {Query = "foobar"};

            Assert.Throws<NutritionixException>(() =>
            {
                _nutritionix.SearchItems(request);
            });
        }

        [Fact]
        public void Search_ThrowsNutritionixException_WhenNutritionixReturnsErrorResponse()
        {
            var errorResponse = new ErrorResponse
            {
                Errors = new[] {new Error {Code = "404", Message = "No item found with id fake"}}
            };
            var json = JsonConvert.SerializeObject(errorResponse);
            MockResponse(json, HttpStatusCode.NotFound);

            var request = new SearchRequest {Query = "foobar"};

            Assert.Throws<NutritionixException>(() =>
            {
                _nutritionix.SearchItems(request);
            });
        }

        private void MockResponse(string json, HttpStatusCode status = HttpStatusCode.OK)
        {
            var mockHttpResponse = new HttpResponseMessage
            {
                StatusCode = status,
                Content = new StringContent(json)
            };
            _mockHttp
                .Expect(x => x.Response)
                .Return(mockHttpResponse)
                .Repeat.Once();
        }
    }
}
