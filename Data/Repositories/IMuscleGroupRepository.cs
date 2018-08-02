using FitHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHub.Data.Repositories
{
    public interface IMuscleGroupRepository
    {
        IEnumerable<MuscleGroup> GetAllRows();
    }
}
