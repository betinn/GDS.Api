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
        public IActionResult Create(Guid idCard, [FromBody] CreateBoxRequest boxRequest)
        {
            Profile profile = _boxService.Create(idCard, boxRequest);
            return Ok(profile);
        }
        [Authorize]
        [HttpPut("update/{idcard}/{idBox}")]
        public IActionResult Update(Guid idCard, Guid idBox, [FromBody] CreateBoxRequest boxRequest)
        {
            Profile profile = _boxService.Update(idCard, idBox, boxRequest);
            return Ok(profile);
        }
        [Authorize]
        [HttpDelete("delete/{idcard}/{idBox}")]
        public IActionResult Delete(Guid idCard, Guid idBox)
        {
            Profile profile = _boxService.Delete(idCard, idBox);
            return Ok(profile);
        }
    }
}
