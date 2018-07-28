using System.Collections.Generic;
using System.Linq;
using FitHub.Contexts;
using FitHub.Data.Entities;

namespace FitHub.Data.Repositories
{
    public class FitRepository : IFitRepository
    {
        private readonly CustomIdentityContext _identityContext;

        public FitRepository(CustomIdentityContext identityContext)
        {
            _identityContext = identityContext;
        }


        public IEnumerable<Result> GetAllRows()
        {
            return _identityContext.Results.ToList();
        }

        public Result FindRowByID(int ID)
        {
            return _identityContext.Results.First(r => r.ID == ID);
        }

        public bool SaveAll()
        {
            return _identityContext.SaveChanges() > 0;
        }


    }
}
