using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record BoatAvailability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public int Year { get; set; }
        public Boat? Boat { get; set; }
        public ICollection<CalendarException>? CalendarExceptions { get; set; }
    }
}