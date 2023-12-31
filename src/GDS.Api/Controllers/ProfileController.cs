using Microsoft.AspNetCore.Mvc;

namespace GDS.Api.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
