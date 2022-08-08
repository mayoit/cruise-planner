using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingTrip.Domain.EventSourcingDomain
{
    [Table("Events")]
    public record EventSource
    {
        public EventSource()
        {
            EntityId = Guid.NewGuid();
        }
        public Guid EntityId { get; set; }

        public int Version { get; set; }


        [Required] public string? Payload { get; set; }

        public string? DomainEventType { get; set; }

        public string? TraceId { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
