using System.Linq;
using FitHub.Contexts;
using FitHub.Data;
using FitHub.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitHub.Controllers
{
    public class UserInputController : Controller
    {

        [HttpGet]
        public IActionResult UserInput()
        {
            return View("UserInput");
        }
    }
}