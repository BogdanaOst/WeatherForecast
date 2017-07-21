using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppContext db;
        private HistoryRepository historyRepository;
        private SelectedCitiesRepository selectedCitiesRepository;
       
        public UnitOfWork()
        {
            db = new AppContext("DefaultConnection");
        }
        public UnitOfWork(string connectionString)
        {
            db = new AppContext(connectionString);
            
        }

        public IRepository<HistoryModel> History
        {
            get
            {
                if (historyRepository == null)
                    historyRepository = new HistoryRepository(db);
                return historyRepository;
            }
        }


        public IRepository<SelectedCity> SelectedCities
        {
            get
            {
                if (selectedCitiesRepository == null)
                    selectedCitiesRepository = new SelectedCitiesRepository(db);
                return selectedCitiesRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
