using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitHub.Data.Entities;
using FitHub.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitHub.Data.Models.FitFile
{
    public class FitFileExercisesModel
    {
        private readonly IExerciseRepository _exerciseRepository;
        public IEnumerable<Exercise> Exercises { get; set; }
        public SelectListItem ExerciseList { get; set; }
       

        public FitFileExercisesModel(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
            Exercises = _exerciseRepository.GetAllRows().ToList();
        }


    }
}
