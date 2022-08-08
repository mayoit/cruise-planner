using FishingTrip.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record TripMember
    {
        public string? PhoneNumber { get; set; }
        [ForeignKey(nameof(PhoneNumber))]
        public UserProfile? Profile { get; set; }
        public User? User { get; set; }
        public TripMemberRole Role { get; set; }
    }
}