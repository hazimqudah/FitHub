using FitHub.Contexts;
using FitHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHub.Data.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly CustomIdentityContext _identityContext;

        public WorkoutRepository(CustomIdentityContext identityContext)
        {
            _identityContext = identityContext;
        }


        public IEnumerable<Workout> GetAllRows()
        {
            return _identityContext.Workouts.ToList();
        }

        public Workout FindRowByID(int ID)
        {
            return null;
            //return _identityContext.Workouts.First(r => r.WoUserID.E ID);
        }

        public bool SaveAll()
        {
            return _identityContext.SaveChanges() > 0;
        }

        public IEnumerable<Workout> GetCurrentUserWorkoutDates(string currentUserID)
        {
            return _identityContext.Workouts
                                   .Where(p => p.WoUserID == currentUserID)
                                   .Select(d => new Workout {
                                       WoDate = d.WoDate
                                   }).Distinct().ToList();
        }

        public IEnumerable<Workout> GetWorkoutsForCurrentUserOnGivenDate(string currentUserId, string workoutDate)
        {
            return _identityContext.Workouts
                                   .Where(p => p.WoUserID == currentUserId)
                                   .Where(p => p.WoDate == DateTime.Parse(workoutDate))
                                   .Select(x => new Workout {
                                       WoId = x.WoId,
                                       WoDate = x.WoDate,
                                       WoExID = x.WoExID,
                                       WoSetCount = x.WoSetCount,
                                       WoRepCount = x.WoRepCount,
                                       WoWeightUsed = x.WoWeightUsed
                                   })
                                   .ToList();
        }
    }
}
