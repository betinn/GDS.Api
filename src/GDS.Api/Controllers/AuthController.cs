using Microsoft.AspNetCore.Mvc;
using GDS.Api.Filter;
using GDS.Api.Model.Response;
using GDS.Api.Model.Request;
using GDS.Api.Service.Interface;
using GDS.Api.Model.Configuration;
using Microsoft.AspNetCore.Authorization;
using GDS.Api.Util;

namespace GDS.Api.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _IServiceProvider;
        public AuthController(IAuthService authService, IServiceProvider serviceProvider)
        {
            _authService = authService;
            _IServiceProvider = serviceProvider;
        }

        [HttpGet("{ProfileId}")]
        public IActionResult AuthProfile(Guid ProfileId)
        {
            return Ok();
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
