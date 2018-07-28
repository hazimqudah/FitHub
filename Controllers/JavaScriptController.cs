using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitHub.Controllers
{
    public class JavaScriptController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult JavaScript()
        {
            ViewBag.method = "GET";

            return View();
        }

        [HttpPost]
        public IActionResult JavaScript(string post)
        {
            ViewBag.method = "POST";
            return View();
        }
    }
}