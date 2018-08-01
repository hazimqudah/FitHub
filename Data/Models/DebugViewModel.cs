using FitHub.Data.Entities;
using System.Collections.Generic;

namespace FitHub.Data.Models
{
    public class DebugViewModel
    {
        public IEnumerable<Workout> ListOfWorkoutsForUserID;
        public IEnumerable<Workout> ListOfWorkoutsForUserIDGivenDate;

    }
}
