namespace FishingTrip.Domain.DetailedDomains
{
    public class PortProfile
    {
        public string? Name { get; set; }
        public string? NameEnglish { get; set; }
        public string? PortAddress { get; set; }
        public string? MainPhoneNumber { get; set; }
        public string? SecondaryPhoneNumber { get; set; } // nullable
        public string? EmailAddress { get; set; } // nullable
        public bool RequiresLicenseBEforeArrival { get; set; } // nullable 
        public string? RequiredDocuments { get; set; } // nullable
        public LocationCoordinate? Location { get; set; }
        public string? MoreInfo { get; set; }
    }
}