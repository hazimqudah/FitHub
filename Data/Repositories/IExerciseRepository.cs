using System.Collections.Generic;
using FitHub.Data.Entities;

namespace FitHub.Data.Repositories
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllRows();
        Exercise FindExerciseNameByID(int exerciseID);
        Exercise FindRowByID(string exerciseName);
        void AddExercise(string exerciseName);
        bool SaveAll();
    }
}