using Microsoft.AspNetCore.Mvc;
using GDS.Api.Filter;
using GDS.Api.Model.Response;
using GDS.Api.Model.Request;
using GDS.Api.Service.Interface;
using GDS.Api.Model.Configuration;
using Microsoft.AspNetCore.Authorization;
using GDS.Api.Util;
using System.ComponentModel.DataAnnotations;
using GDS.Api.Model;

namespace GDS.Api.Controllers
{
    [ModelValidation]
    [Route("Auth")]
    public class AuthController(IAuthService authService,
        IServiceProvider serviceProvider,
        IProfileService profileService) : Controller
    {
        private readonly IAuthService _authService = authService;
        private readonly IServiceProvider _IServiceProvider = serviceProvider;
        private readonly IProfileService _profileService = profileService;
        
        

        [HttpPost()]
        public IActionResult AuthProfile([FromBody] AuthProfileRequest authProfile)
        {
            Profile profile = _profileService.DecryptProfile(authProfile);
            profile.FileName = authProfile.ProfileFilePath;
            var token = _authService.CreateAccessToken(
                new CreateTokenRequest()
                {
                    Password = authProfile.Password,
                    User = authProfile.User,
                    ProfileFileName = authProfile.ProfileFilePath
                });
            return Ok(new { access_token = token, profile });
        }
        [Authorize]
        [HttpGet("Check")]
        public IActionResult CheckAuthentication()
        {
            return Ok(_authService.GetProfileSettings());
        }

        [HttpPost("CreateToken")]
        public IActionResult CreateToken([FromBody] CreateTokenRequest tokenRequest)
        {
            
            var token = _authService.CreateAccessToken(tokenRequest);
            return Ok(new {access_token = token});
        }
    }
}
