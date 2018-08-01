using FitHub.Data.Entities;
using FitHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHub.Data.Repositories
{
    public interface IWorkoutRepository
    {
        IEnumerable<Workout> GetAllRows();
        IEnumerable<Workout> GetCurrentUserWorkoutDates(string currentUserId);
        IEnumerable<Workout> GetWorkoutsForCurrentUserOnGivenDate(string currentUserId, string workoutDate);
        void LogWorkoutSet(List<LogExerciseModel> workoutSet);
        Workout FindRowByID(int ID);
        bool SaveAll();
    }
}
