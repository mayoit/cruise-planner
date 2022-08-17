using FishingTrip.Application.Interface;
using FishingTrip.Domain.FishingTripDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace FishingTrip.API.Controllers
{

    [ApiController]
    [Route("Gallery")]
    public class GalleryController : ControllerBase
    {
        private readonly ILogger<GalleryController> _logger;
        private readonly IFishingTripPlannerDbContext fishingTripPlannerDbContext;

        public GalleryController(IFishingTripPlannerDbContext fishingTripPlannerDbContext, ILogger<GalleryController> logger)
        {
            _logger = logger;
            this.fishingTripPlannerDbContext = fishingTripPlannerDbContext;
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get Profile",
            Description = "Retrieves Profile by Id",
            OperationId = "get-Profile")]
        [Route("{profileId}")]
        [ProducesResponseType(typeof(UserProfile), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

        public Task<UserProfile?> GetProfileAsync([FromRoute] string profileId) => fishingTripPlannerDbContext.UserProfiles.FirstOrDefaultAsync();

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get Profiles",
            Description = "Retrieves Profile by email",
            OperationId = "get-Profiles")]
        [ProducesResponseType(typeof(List<UserProfile>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public Task<List<UserProfile>> GetProfilesAsync([FromQuery] string email) => fishingTripPlannerDbContext.UserProfiles.Where(profile => profile.Email == "atef.aziz@work").ToListAsync();

        [HttpPost]
        [SwaggerOperation(
           Summary = "Add Profile",
           Description = "Retrieves Profile by email",
           OperationId = "add-Profile")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public Task<int> AddProfileAsync(string email, string phone)
        {
            fishingTripPlannerDbContext.Add(new UserProfile { Email = email, PhoneNumber = phone });
            return fishingTripPlannerDbContext.SaveChangesAsync();
        }
    }
}
