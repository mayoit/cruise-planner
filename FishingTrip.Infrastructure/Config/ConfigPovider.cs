
using FishingTrip.Application.Interface.Config;

namespace FishingTrip.Infrastructure.Config
{
    internal class ConfigProvider : IConfigProvider
    {
        public string FishingTripDbConnectionString { get; } = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=newsimpleFishing;Pooling=true";
    }
}