namespace FishingTrip.Domain.WeatherDomain
{
    public record ForecastRecord
    {
        public DateOnly? ForecastDate { get; set; }
        public TimeOnly? ForecastTime { get; set; }
        public Tide? Tide { get; set; }
        public Temperature? Temperature { get; set; }
    }
}
