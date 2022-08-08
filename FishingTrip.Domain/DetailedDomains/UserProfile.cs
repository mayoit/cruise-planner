namespace FishingTrip.Domain.DetailedDomains
{
    public class UserProfile
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string GetFullName() => $"{FirstName} {LastName}";
        public DateOnly? DateOfBirth { get; set; }
        public UserProfile()
        {

        }
    }
}