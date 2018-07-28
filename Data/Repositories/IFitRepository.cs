using System.Collections.Generic;
using FitHub.Data.Entities;

namespace FitHub.Data.Repositories
{
    public interface IFitRepository
    {
        IEnumerable<Result> GetAllRows();
        Result FindRowByID(int ID);
        bool SaveAll();
    }
}