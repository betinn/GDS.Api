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
    }
}
