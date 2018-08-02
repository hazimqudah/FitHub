using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitHub.Contexts;
using FitHub.Data.Entities;

namespace FitHub.Data.Repositories
{
    public class MuscleGroupRepository : IMuscleGroupRepository
    {

        private readonly CustomIdentityContext _identityContext;

        public MuscleGroupRepository(CustomIdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public IEnumerable<MuscleGroup> GetAllRows()
        {
            return _identityContext.MuscleGroups.ToList();
        }
    }
}
