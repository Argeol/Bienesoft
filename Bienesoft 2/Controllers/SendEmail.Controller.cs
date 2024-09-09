using Microsoft.AspNetCore.Mvc;

namespace Bienesoft.Controllers
{
    public class SendEmail : Controller
    {
        [ApiController]
        Route("api/[")
        public IActionResult Index()
        {
            return View();
        }
    }
}
