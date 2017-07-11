using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SelectedCitiesRepository : IRepository<SelectedCity>
    {
        private AppContext db;

        public SelectedCitiesRepository(AppContext context)
        {
            db = context;
        }

        public List<SelectedCity> GetAll()
        {
            return db.SelectedCities.ToList();
        }

        public SelectedCity GetById(int id)
        {
            return db.SelectedCities.Find(id);
        }

        public void Create(SelectedCity model)
        {
            db.SelectedCities.Add(model);
        }

        public void Update(SelectedCity model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SelectedCity model = db.SelectedCities.Find(id);
            if (model != null)
                db.SelectedCities.Remove(model);
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
