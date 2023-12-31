using Microsoft.AspNetCore.Mvc;
using GDS.Api.Filter;
using GDS.Api.Model.Response;
using GDS.Api.Filter.Attribute;

namespace GDS.Api.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        [HttpPost("{ProfileId}")]
        public IActionResult AuthProfile(Guid ProfileId)
        {
            return Ok();
        }
        [ProfileAuthorization]
        [HttpGet("Check")]
        public IActionResult CheckAuthentication()
        {
            return Ok(new CheckAuthenticationResponse());
        }
    }
}
