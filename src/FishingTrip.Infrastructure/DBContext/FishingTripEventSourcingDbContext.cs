using FishingTrip.Domain.EventSourcingDomain;
using Microsoft.EntityFrameworkCore;
namespace FishingTrip.Infrastructure.DBContext
{
    public class FishingTripEventSourcingDbContext : DbContext
    {
        public DbSet<EventSource>? Events { get; set; }
        public FishingTripEventSourcingDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}