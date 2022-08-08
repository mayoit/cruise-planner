using FishingTrip.Infrastructure.DI;
using Microsoft.AspNetCore;
namespace FishingTrip.API
{
    public class Program
    {
        public static Task Main(string[] args)
        => BuildWebHost(args)
                .RunAsync();

        public static IWebHost BuildWebHost(string[] args)
        => WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
            })
            .ConfigureServices((app, services) =>
            {
                services.AddConfiguration();
            }).UseStartup<Startup>().Build();
    }
}