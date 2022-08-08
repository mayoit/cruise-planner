using FishingTrip.Application.Interface;
using FishingTrip.Application.Interface.Config;
using Microsoft.EntityFrameworkCore;

namespace FishingTrip.Infrastructure.DBContext
{
    internal class FishingTripPlannerDbContextProvider : IDbContextProvider<FishingTripPlannerDbContext>, IDbContextConfigProvider<FishingTripPlannerDbContext>
    {
        protected readonly IConfigProvider configProvider;
        public FishingTripPlannerDbContextProvider(IConfigProvider _configProvider)
        {
            configProvider = _configProvider;
        }
        public FishingTripPlannerDbContext Get()
        {
            var dbContext = new FishingTripPlannerDbContext(GetContextConfig());
            return dbContext;
        }
        public DbContextOptions<FishingTripPlannerDbContext> GetContextConfig()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FishingTripPlannerDbContext>();
            if (string.IsNullOrEmpty(configProvider.FishingTripDbConnectionString))
                throw new Exception($"Cannot get database connection string ");
            DbContextOptionsBuilder<FishingTripPlannerDbContext> dbContextOptionsBuilder = optionsBuilder.UseNpgsql(configProvider.FishingTripDbConnectionString);
            return optionsBuilder.Options;
        }
    }
}