using System.Collections.Generic;
using FitHub.Data.Entities;

namespace FitHub.Data.Repositories
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllRows();
        Exercise FindRowByID(int ID);
        void AddExercise(string exerciseName);
        bool SaveAll();
    }
}