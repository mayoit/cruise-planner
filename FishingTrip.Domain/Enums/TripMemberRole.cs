using System.Runtime.Serialization;

namespace FishingTrip.Domain.Enums
{
    public enum TripMemberRole
    {
        [EnumMember(Value = "CAPTAIN")]
        Captain,
        [EnumMember(Value = "MEMBER")]
        Member,
        [EnumMember(Value = "CAPTAIN")]
        Admin,
        [EnumMember(Value = "Crew")]
        Crew
    }
}
