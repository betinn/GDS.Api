using GDS.Api.Filter;
using GDS.Api.Model.Request;
using GDS.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GDS.Api.Service.Interface;

namespace GDS.Api.Controllers
{
    [ModelValidation]
    [Route("box")]
    public class BoxController(IBoxService boxService) : Controller
    {
        private readonly IBoxService _boxService = boxService;
        [Authorize]
        [HttpPost("create/{idcard}")]
        public IActionResult Create(Guid idcard, [FromBody] CreateBoxRequest boxRequest)
        {
            Profile profile = _boxService.Create(idcard, boxRequest);
            return Ok(profile);
        }
    }
}
