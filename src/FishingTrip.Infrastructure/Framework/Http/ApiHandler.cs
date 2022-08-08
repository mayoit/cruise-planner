using Microsoft.Extensions.Options;

namespace FishingTrip.Infrastructure.Framework.Http
{
    internal abstract class ApiHandler<TRequestHeaders> : DelegatingHandler
        where TRequestHeaders : class
    {
        protected readonly TRequestHeaders _requestHeaders;

        public ApiHandler(IOptions<TRequestHeaders> options) => _requestHeaders = options.Value;
        public abstract IReadOnlyDictionary<string, string[]> GetHttpRequestHeaders();
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestHeaders = GetHttpRequestHeaders();
            if (requestHeaders != null && requestHeaders.Any())
            {
                foreach (var header in requestHeaders)
                    request.Headers.Add(header.Key, header.Value);
            }
            var response = await base.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
