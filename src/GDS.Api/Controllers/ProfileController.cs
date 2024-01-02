using GDS.Api.Filter;
using GDS.Api.Model.Request;
using GDS.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GDS.Api.Controllers
{
    [ModelValidation]
    [Route("profile")]
    public class ProfileController(IProfileService profileService) : Controller
    {
        private readonly IProfileService _profileService = profileService;
        [HttpGet("listprofiles")]
        public IActionResult ListProfilesFromBaseDiretory()
        {
            var response = _profileService.ListProfilesFromBaseDiretory();
            if (response.Count > 0) return Ok(response);
            else return NoContent();
        }
        [HttpPost("create")]
        public IActionResult CreateProfile([FromBody] CreateProfileRequest createProfile)
        {
            return Ok();
        }
    }
}
