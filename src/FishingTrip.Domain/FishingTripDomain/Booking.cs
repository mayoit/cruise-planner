using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; init; }
        public virtual User? BookedByUser { get; init; }
        public DateOnly Date { get; init; }
        public TimeOnly Time { get; init; }
    }
}
