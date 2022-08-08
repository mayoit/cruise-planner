using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FishingTrip.Infrastructure.DI
{
    public static class DatabaseRegistrationExtension
    {
        public static IServiceCollection AddPostgresDatabaseContext<ITDbCOntext, TDbCOntext>(this IServiceCollection serviceCollection,
              string connectionString)
            where TDbCOntext : DbContext
            where ITDbCOntext : class
        {
            serviceCollection.AddDbContext<TDbCOntext>(
                options =>
                    {
                        options.EnableDetailedErrors();
                        NpgsqlDbContextOptionsBuilderExtensions
                        .UseNpgsql(options, connectionString);

                    });
            serviceCollection.AddScoped(typeof(ITDbCOntext), typeof(TDbCOntext));
            return serviceCollection;
        }
    }
}