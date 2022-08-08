using FishingTrip.Domain.FishingTripDomain;
using Microsoft.EntityFrameworkCore;


namespace FishingTrip.Application.Interface
{
    public interface IFishingTripPlannerDbContext : IDbContext

    {
        public DbSet<Boat>? Boats { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserProfile>? UserProfiles { get; set; }
    }
}