using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateOnly? DepartureDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public ICollection<TripMember>? TripMembers { get; set; }
        public Port? DeparturePort { get; set; }
        public Port? ReturnPort { get; set; }
    }
}
