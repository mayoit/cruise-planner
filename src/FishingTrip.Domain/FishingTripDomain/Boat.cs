using FishingTrip.Domain.DetailedDomains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record Boat
    {
        public Boat()
        {
            Created = DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; init; }
        public DateTime Created { get; init; }
        public User? Owner { get; init; }
        [Column(TypeName = "jsonb")]
        public BoatProfile? Profile { get; init; }
        public Port? OperatingPort { get; init; }
        public string? GetCurrentPortName(string locale) => OperatingPort?.GetName(locale);
        public string? GetName(string locale) => locale == "" ? Profile?.Name : Profile?.NameEnglish;
    }
}