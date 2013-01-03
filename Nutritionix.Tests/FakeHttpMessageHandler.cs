using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Nutritionix.Tests
{
    public abstract class FakeHttpMessageHandler : HttpMessageHandler
    {
        public abstract HttpResponseMessage Response { get; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => Response);
        }
    }
}