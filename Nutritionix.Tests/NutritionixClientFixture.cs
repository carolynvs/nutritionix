using System.Net;
using System.Net.Http;
using System.Web;
using NUnit.Framework;
using Newtonsoft.Json;
using Rhino.Mocks;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class NutritionixClientFixture
    {
        private FakeHttpMessageHandler _mockHttp;
        private NutritionixClient _nutritionix;

        [SetUp]
        public void Setup()
        {
            _mockHttp = MockRepository.GeneratePartialMock<FakeHttpMessageHandler>();
            _nutritionix = new NutritionixClient(() => new HttpClient(_mockHttp));
            _nutritionix.Initialize("myAppId", "myAppKey");
        }

        [Test]
        public void Search_ReturnsEmptyResults_WhenResultsIsNull()
        {
            var sampleResponse = new SearchResponse
            {
                TotalResults = 0,
                Results = null
            };
            var json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var request = new SearchRequest {Query = "foobar"};
            var response = _nutritionix.SearchItems(request);

            Assert.IsNotNull(response.Results);
            Assert.AreEqual(0, response.Results.Length);
        }

        [Test]
        public void Search_ReturnsPopulatedResults()
        {
            var sampleResponse = new SearchResponse
            {
                TotalResults = 1,
                Results = new[] {new SearchResult()}
            };
            var json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var request = new SearchRequest {Query = "foobar"};
            var response = _nutritionix.SearchItems(request);

            Assert.AreEqual(1, response.Results.Length);
        }

        [Test]
        public void PowerSearch_ReturnsPopulatedResults()
        {
            var sampleResponse = new SearchResponse
            {
                TotalResults = 1,
                Results = new[] {new SearchResult()}
            };
            var json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var request = new PowerSearchRequest {Query = "foobar"};
            var response = _nutritionix.SearchItems(request);

            Assert.AreEqual(1, response.Results.Length);
        }

        [Test]
        [ExpectedException(typeof(NutritionixException))]
        public void Search_ThrowsNutritionixException_WhenResponseContainsUnparseableJson()
        {
            MockResponse("<!_foobar'd");

            var request = new SearchRequest {Query = "foobar"};
            _nutritionix.SearchItems(request);
        }

        [Test]
        [ExpectedException(typeof(HttpException))]
        public void Search_ThrowsNutritionixException_WhenBadResponseisReturned()
        {
            MockResponse(string.Empty, HttpStatusCode.BadRequest);

            var request = new SearchRequest {Query = "foobar"};
            var response = _nutritionix.SearchItems(request);

            Assert.AreEqual(0, response.Results.Length);
        }

        [Test]
        [ExpectedException(typeof(NutritionixException))]
        public void Search_ThrowsNutritionixException_WhenNutritionixReturnsErrorResponse()
        {
            var errorResponse = new ErrorResponse
            {
                Errors = new[] {new Error {Code = "404", Message = "No item found with id fake"}}
            };
            var json = JsonConvert.SerializeObject(errorResponse);
            MockResponse(json, HttpStatusCode.NotFound);

            var request = new SearchRequest {Query = "foobar"};
            _nutritionix.SearchItems(request);
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
