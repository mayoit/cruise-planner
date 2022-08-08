using Microsoft.EntityFrameworkCore;

namespace FishingTrip.Infrastructure.DBContext
{
    public interface IDbContextConfigProvider<TDbContext>
        where TDbContext : DbContext
    {
        DbContextOptions<TDbContext> GetContextConfig();
    }
}
