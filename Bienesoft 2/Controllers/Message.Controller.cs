using Microsoft.AspNetCore.Mvc;

namespace Bienesoft.Controllers
{
    public class Message : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
