using System.ComponentModel.DataAnnotations;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record User
    {
        [Key] public long Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string? UserName { get; set; }
        public UserProfile? Profile { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<TripMember>? Trips { get; set; }
    }
}