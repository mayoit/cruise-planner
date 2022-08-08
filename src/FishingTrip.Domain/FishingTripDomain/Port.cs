using FishingTrip.Domain.DetailedDomains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.FishingTripDomain
{
    public record Port
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; init; }

        [Column(TypeName = "jsonb")]
        public PortProfile? Profile { get; init; }
        public string? GetName(string locale) => locale == "" ? Profile?.Name : Profile?.NameEnglish;
    }
}