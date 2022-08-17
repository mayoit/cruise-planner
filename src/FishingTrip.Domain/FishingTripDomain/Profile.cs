using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record UserProfile
    {
        [MaxLength(100)]
        public string? Email { get; init; }
        [Required]
        [Column(TypeName = "jsonb")]
        public UserProfile? ProfileDetails { get; init; }

        [Key]
        [MaxLength(15)]
        [Required]
        public string? PhoneNumber { get; init; }

        public long? DefaultUserId { get; init; }
        [ForeignKey(nameof(DefaultUserId))]
        public User? DefaultUser { get; init; }

        public ICollection<TripMember>? Trips { get; init; }
        public bool IsActive { get; init; }
        public UserProfile() => IsActive = true;
    }
}
