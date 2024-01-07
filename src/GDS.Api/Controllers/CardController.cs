using GDS.Api.Filter;
using GDS.Api.Model.Request;
using GDS.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GDS.Api.Controllers
{
    [ModelValidation]
    [Route("card")]
    public class CardController(ICardService cardService) : Controller
    {
        private readonly ICardService _cardService = cardService;
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateCardRequest cardRequest)
        {
            return Ok(_cardService.Create(cardRequest));
        }
        [HttpPut("update/{idCard}")]
        public IActionResult Update(Guid idCard, [FromBody] UpdateCardRequest updateCardRequest)
        {
            return Ok(_cardService.Update(idCard, updateCardRequest));
        }
        [HttpDelete("delete/{idCard}")]
        public IActionResult Delete(Guid idCard)
        {
            return Ok(_cardService.Delete(idCard));
        }
    }
}
