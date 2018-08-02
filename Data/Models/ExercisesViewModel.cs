using FitHub.Contexts;
using FitHub.Data.Entities;
using FitHub.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHub.Data.Models
{
    public class ExercisesViewModel
    {
        private readonly CustomIdentityContext _identityContext;

        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMuscleGroupRepository _muscleGroupRepository;

        public IEnumerable<MuscleGroup> MuscleGroups { get; set; }
        public IEnumerable<Exercise> ExercisesForMuscleGroup { get; set; }

        public ExercisesViewModel(CustomIdentityContext identityContext, IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository, IMuscleGroupRepository muscleGroupRepository)
        {
            _identityContext = identityContext;
            _exerciseRepository = exerciseRepository;
            _workoutRepository = workoutRepository;
            _muscleGroupRepository = muscleGroupRepository;
        }

        public void GetMuscleGroups()
        {
            MuscleGroups = _muscleGroupRepository.GetAllRows();
        }

        public void GetExercisesForMuscleGroup(int MgId)
        {
            ExercisesForMuscleGroup = _identityContext.Exercises.Where(e => e.ExMgID == MgId).ToList();
        }

    }
}
