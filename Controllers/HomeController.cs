using System;
using System.Diagnostics;
using System.Linq;
using FitHub.Contexts;
using FitHub.Data;
using FitHub.Data.Models;
using FitHub.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomIdentityContext _identityDbContext;
        private ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, CustomIdentityContext _identityContext)
        {
            _identityDbContext = _identityContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Database()
        {
            //var query = _context.Results.ToList();

            //var linkedQuery = from p in _context.Results select p;

            _logger.LogInformation("Database GET request yal gawwad!!!");
            ViewBag.method = "GET";

            return View();
            //return View(_identityDbContext.Results.ToList());
            //return View(_repository.GetAllRows().ToList());
        }

        [HttpPost]
        public IActionResult Database(string ID, string queryColumn, string queryValue)
        {
            if (!String.IsNullOrEmpty(ID)) // no ID entered!
            {
                ViewBag.method = "POST: run query to find ID: " + ID + "!";
                //var response = _repository.FindRowByID(Convert.ToInt32(ID));

                //ViewBag.method = "fN: " + response.FirstName + " lN: " + response.LastName + " comment: " + response.Comment + "!";
            }

            //ViewBag.method = "POST: queryColumn was " + queryColumn + " and queryValue was " + queryValue + "!";
            return View();
            //return View(_repository.GetAllRows().ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
