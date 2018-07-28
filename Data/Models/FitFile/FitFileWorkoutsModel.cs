

using FitHub.Contexts;
using FitHub.Controllers;
using FitHub.Data.Entities;
using FitHub.Data.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FitHub.Data.Models.FitFile
{
    public class FitFileWorkoutsModel
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        public CustomIdentityContext _identityContext;

        public IEnumerable<Workout> AllWorkoutRows { get; set; }
        public IEnumerable<Workout> WorkoutDatesForUser { get; set; }
        public IEnumerable<Workout> WorkoutsOnSelectedDateForUser { get; set; }

        private ILogger<FitFileController> _logger;


        public FitFileWorkoutsModel(IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository, CustomIdentityContext identityContext, ILogger<FitFileController> logger)
        {
            _identityContext = identityContext;
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _logger = logger;
        }

        public string FindExerciseNameFromID(int ID)
        {
            return _exerciseRepository.FindRowByID(ID).ExName;
        }

        public void GetAllWorkoutRows()
        {
            AllWorkoutRows = _workoutRepository.GetAllRows();
        }

        public void FindUniqueWorkoutDatesForUser(string currentUserId)
        {
            WorkoutDatesForUser = _workoutRepository.GetCurrentUserWorkoutDates(currentUserId);
        }

        public void FindWorkoutsOnSelectedDateForUser(string CurrentUserID, string SelectedWorkoutDateForUser)
        {
            WorkoutsOnSelectedDateForUser = _workoutRepository.GetWorkoutsForCurrentUserOnGivenDate(CurrentUserID, SelectedWorkoutDateForUser);

            _logger.LogInformation("finding workout on date " + SelectedWorkoutDateForUser + " for user id: " + CurrentUserID);
            //WorkoutsOnSelectedDateForUser = null;
        }
    }
}
