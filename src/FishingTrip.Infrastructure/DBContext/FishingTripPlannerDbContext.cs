using FishingTrip.Application.Interface;
using FishingTrip.Domain.FishingTripDomain;
using Microsoft.EntityFrameworkCore;
namespace FishingTrip.Infrastructure.DBContext
{
    public class FishingTripPlannerDbContext : DbContext, IFishingTripPlannerDbContext
    {
        public DbSet<Boat>? Boats { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserProfile>? UserProfiles { get; set; }
        public FishingTripPlannerDbContext(DbContextOptions<FishingTripPlannerDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProfile>().HasKey(key => key.PhoneNumber);
            builder.Entity<TripMember>().HasKey(key => new { key.PhoneNumber, key.Role });
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}