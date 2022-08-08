using Microsoft.Extensions.Options;

namespace FishingTrip.Infrastructure.Framework.Http.Weather
{
    internal class WeatherApiHandler : ApiHandler<WeatherApiHeaders>
    {

        public WeatherApiHandler(IOptions<WeatherApiHeaders> options) : base(options) { }
        public override IReadOnlyDictionary<string, string[]> GetHttpRequestHeaders()
        {
            return new Dictionary<string, string[]>
            {
                {
                    _requestHeaders.ApiKey?._key,
                    new[] { _requestHeaders.ApiKey?._value }
                },
                {
                    _requestHeaders.ResponceType?._key,
                    new[] { _requestHeaders.ResponceType._value }
                }
            };
        }
    }
}