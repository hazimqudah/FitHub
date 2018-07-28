using System;
using System.Diagnostics;
using System.Linq;
using FitHub.Contexts;
using FitHub.Data;
using FitHub.Data.Models;
using FitHub.Data.Models.FitFile;
using FitHub.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CustomIdentityContext _identityDbContext;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutRepository _workoutRepository;
        public string CurrentUserID;
        private ILogger<HomeController> _logger;


        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger, CustomIdentityContext _identityContext, IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository)
        {
            _userManager = userManager;
            _identityDbContext = _identityContext;
            _exerciseRepository = exerciseRepository;
            _workoutRepository = workoutRepository;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Log()
        {
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityDbContext, _logger);
            CurrentUserID = _userManager.GetUserId(HttpContext.User);

            model.GetAllWorkoutRows();
            model.FindUniqueWorkoutDatesForUser(CurrentUserID);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Log(string DateOfWorkout)
        {
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityDbContext, _logger);

            model.DateToLog = DateOfWorkout;

            CurrentUserID = _userManager.GetUserId(HttpContext.User);

            //model.GetAllWorkoutRows();
            //model.FindUniqueWorkoutDatesForUser(CurrentUserID);
            //  model.FindWorkoutsOnSelectedDateForUser(CurrentUserID, SelectedWorkoutDateForUser);

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Exercises()
        {
            _logger.LogInformation("Database GET request yal gawwad!!!");
            ViewBag.method = "GET";

            FitFileExercisesModel tempModel = new FitFileExercisesModel(_exerciseRepository);

            foreach (var c in tempModel.Exercises)
            {
                _logger.LogInformation("Exercise logged: " + c.ExName);
            }

            return View(new FitFileExercisesModel(_exerciseRepository));
        }

        [HttpPost]
        public IActionResult Exercises(string exerciseName)
        {
            _logger.LogInformation("trying to add: " + exerciseName);

            _exerciseRepository.AddExercise(exerciseName);

            return View(new FitFileExercisesModel(_exerciseRepository));
        }

        [Authorize]
        [HttpGet]
        public IActionResult History()
        {
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityDbContext, _logger);
            CurrentUserID = _userManager.GetUserId(HttpContext.User);

            model.GetAllWorkoutRows();
            model.FindUniqueWorkoutDatesForUser(CurrentUserID);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult History(string SelectedWorkoutDateForUser)
        {
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityDbContext, _logger);
            CurrentUserID = _userManager.GetUserId(HttpContext.User);

            model.GetAllWorkoutRows();
            model.FindUniqueWorkoutDatesForUser(CurrentUserID);
            model.FindWorkoutsOnSelectedDateForUser(CurrentUserID, SelectedWorkoutDateForUser);

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
