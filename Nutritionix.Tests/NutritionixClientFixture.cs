using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Newtonsoft.Json;
using Rhino.Mocks;

namespace Nutritionix.Tests
{
    [TestFixture]
    public class NutritionixClientFixture
    {
        private FakeHttpMessageHandler _mockHttp;

        [SetUp]
        public void Setup()
        {
            Factory.MockHttpClient = _mockHttp = MockRepository.GeneratePartialMock<FakeHttpMessageHandler>();
        }

        [Test]
        public void Search_ReturnsEmptyResults_WhenResultsIsNull()
        {
            var sampleResponse = new NutritionixSearchResponse
                {
                    TotalResults = 0,
                    Results = null
                };
            string json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var client = new NutritionixClient();
            var request = new NutritionixSearchRequest { Query = "foobar" };
            NutritionixSearchResponse response = client.SearchItems(request);

            Assert.IsNotNull(response.Results);
            Assert.AreEqual(0, response.Results.Length);
        }

        [Test]
        public void Search_ReturnsPopulatedResults()
        {
            var sampleResponse = new NutritionixSearchResponse
                {
                    TotalResults = 1,
                    Results = new[] { new NutritionixSearchResult() }
                };
            string json = JsonConvert.SerializeObject(sampleResponse);
            MockResponse(json);

            var client = new NutritionixClient();
            var request = new NutritionixSearchRequest { Query = "foobar" };
            NutritionixSearchResponse response = client.SearchItems(request);

            Assert.AreEqual(1, response.Results.Length);
        }

        [Test]
        [ExpectedException(typeof(NutritionixException))]
        public void Search_ThrowsNutritionixException_WhenResponseContainsUnparseableJson()
        {
            MockResponse("<!_foobar'd");

            var client = new NutritionixClient();
            var request = new NutritionixSearchRequest{Query = "foobar"};
            client.SearchItems(request);
        }

        [Test]
        [ExpectedException(typeof(NutritionixException))]
        public void Search_ThrowsNutritionixException_WhenBadResponseisReturned()
        {
            MockResponse(string.Empty, HttpStatusCode.BadRequest);

            var client = new NutritionixClient();
            var request = new NutritionixSearchRequest { Query = "foobar" };
            NutritionixSearchResponse response = client.SearchItems(request);

            Assert.AreEqual(0, response.Results.Length);
        }

        [Test]
        [ExpectedException(typeof(NutritionixException))]
        public void Search_ThrowsNutritionixException_WhenNutritionixReturnsErrorResponse()
        {
            var errorResponse = new NutritionixErrorResponse
                {
                    Errors = new[] {new NutritionixError {Code = "404", Message = "No item found with id fake"}}
                };
            var json = JsonConvert.SerializeObject(errorResponse);
            MockResponse(json, HttpStatusCode.NotFound);

            var client = new NutritionixClient();
            var request = new NutritionixSearchRequest { Query = "foobar" };
            client.SearchItems(request);
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
