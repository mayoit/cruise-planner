namespace FishingTrip.Domain.FishingTripDomain
{
    public record CalendarException
    {
        public DateTime DateFrom { get; init; }
        public DateTime DateTo { get; init; }
        public string? Reason { get; init; }
    }
}