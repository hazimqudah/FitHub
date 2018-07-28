using FitHub.Contexts;
using FitHub.Data.Models.FitFile;
using FitHub.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitHub.Controllers
{
    public class FitFileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CustomIdentityContext _identityContext;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutRepository _workoutRepository;
        public string CurrentUserID;
        private ILogger<FitFileController> _logger;

        public FitFileController(UserManager<IdentityUser> userManager, ILogger<FitFileController> logger, CustomIdentityContext identityContext, IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _identityContext = identityContext;
            _exerciseRepository = exerciseRepository;
            _workoutRepository = workoutRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Workouts()
        {
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityContext);
            CurrentUserID = _userManager.GetUserId(HttpContext.User);

            model.GetAllWorkoutRows();
            model.FindUniqueWorkoutDatesForUser(CurrentUserID);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Workouts(string SelectedWorkoutDateForUser)
        {
            FitFileWorkoutsModel model = new FitFileWorkoutsModel(_exerciseRepository, _workoutRepository, _identityContext);
            CurrentUserID = _userManager.GetUserId(HttpContext.User);

            model.GetAllWorkoutRows();
            model.FindUniqueWorkoutDatesForUser(CurrentUserID);
            model.FindWorkoutsOnSelectedDateForUser(CurrentUserID, SelectedWorkoutDateForUser);

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

    }
}