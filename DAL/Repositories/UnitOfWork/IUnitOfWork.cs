using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<HistoryModel> History { get; }
        IRepository<SelectedCity> SelectedCities { get; }
        Task SaveAsync();
    }
}
