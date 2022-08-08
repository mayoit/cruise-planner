using FishingTrip.Application.Interface.Config;
using FishingTrip.Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;

namespace FishingTrip.Infrastructure.DI
{
    public static class ConfigurationRegistrationExtension
    {
        public static void AddConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IConfigProvider), typeof(ConfigProvider));
        }
    }
}
