using FishingTrip.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace FishingTrip.Migrations
{
    internal class FishingTripPlannerDbContextFactory : IDesignTimeDbContextFactory<FishingTripPlannerDbContext>
    {
        public FishingTripPlannerDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            string dbConnectionString = configuration.GetConnectionString("dbConnectionString");
            if (string.IsNullOrEmpty(dbConnectionString))
                throw new Exception(nameof(dbConnectionString));
            var builder = new DbContextOptionsBuilder<FishingTripPlannerDbContext>();
            builder.UseSqlServer(
                dbConnectionString,
                x =>
                {
                    x.MigrationsAssembly("FishingTrip.Migrations");
                    x.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                });

            return new FishingTripPlannerDbContext(builder.Options);
        }
    }
}
