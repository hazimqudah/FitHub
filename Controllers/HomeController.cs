using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FitHub.Contexts;
using FitHub.Data;
using FitHub.Data.Models;
using FitHub.Data.Models.FitFile;
using FitHub.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Log(IFormCollection form)
        {
            List<String> formKeys = Request.Form.Keys.ToList();
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityDbContext, _logger);
            List<LogExerciseModel> workoutSet = new List<LogExerciseModel>();

            string WoDate = Request.Form[formKeys[0]];
            CurrentUserID = _userManager.GetUserId(HttpContext.User);


            for(int i = 1; i < formKeys.Count; i += 4)
            {
                int ex = _exerciseRepository.FindRowByID(Request.Form[formKeys[i]]).ExID;
                string sets = Request.Form[formKeys[i + 1]];
                string reps = Request.Form[formKeys[i + 2]];
                string weights = Request.Form[formKeys[i + 3]];

                workoutSet.Add(new LogExerciseModel
                {
                    WoUserID = CurrentUserID,
                    WoDate = WoDate,
                    WoExID = ex,
                    WoRepCount = int.Parse(reps),
                    WoSetCount = int.Parse(sets),
                    WoWeightUsed = int.Parse(weights)
                });

                //finalString += "Exercise: " + ex + " Sets: " + sets + " Reps: " + reps + " Weights: " + weights + "\n";
            }

            _workoutRepository.LogWorkoutSet(workoutSet);

            //string modelString = "Date: " + WoDate + " User ID: " + CurrentUserID + "\n\n";
            //modelString += finalString;

            //model.DateToLog = modelString;

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

            model.WorkoutsOnSelectedDateForUser = _workoutRepository.GetWorkoutsForCurrentUserOnGivenDate(CurrentUserID, SelectedWorkoutDateForUser);
            
            //model.FindWorkoutsOnSelectedDateForUser(CurrentUserID, SelectedWorkoutDateForUser);

            return View(model);
        }

        [HttpGet]
        public IActionResult Debug()
        {
            CurrentUserID = _userManager.GetUserId(HttpContext.User);
            string WorkoutForUserOnDate = "07-13-2018";

            ViewData["UserID"] = CurrentUserID;
            ViewData["NumberOfWorkoutsForUserID"] = _workoutRepository.GetAllWorkoutsForUserID(CurrentUserID).Count();

            var model = new DebugViewModel();

            model.ListOfWorkoutsForUserID = _workoutRepository.GetAllWorkoutsForUserID(CurrentUserID);

            //model.ListOfWorkoutsForUserIDGivenDate = model.ListOfWorkoutsForUserID.Where(w => w.WoDate.Equals(DateTime.Parse("07-30-2018")));
            model.ListOfWorkoutsForUserIDGivenDate = _workoutRepository.GetWorkoutsForCurrentUserOnGivenDate(CurrentUserID, WorkoutForUserOnDate);

            ViewData["WorkoutForUserOnDate"] = WorkoutForUserOnDate;

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
