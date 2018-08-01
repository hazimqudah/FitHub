using System;
using System.Collections.Generic;
using System.Linq;
using FitHub.Contexts;
using FitHub.Data.Entities;

namespace FitHub.Data.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {

        private readonly CustomIdentityContext _identityContext;

        public ExerciseRepository(CustomIdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public void AddExercise(string exerciseName)
        {
            _identityContext.Exercises.Add(new Exercise()
            {
                ExName = exerciseName
            });

            _identityContext.SaveChanges();
        }

        public IEnumerable<Exercise> GetAllRows()
        {
            return _identityContext.Exercises.ToList();
        }

        public Exercise FindRowByID(string exerciseName)
        {
            return _identityContext.Exercises.Where(e => e.ExName == exerciseName).FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _identityContext.SaveChanges() > 0;
        }
    }
}
