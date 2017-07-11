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
    public class HistoryRepository: IRepository<HistoryModel>
    {
        private AppContext db;

        public HistoryRepository(AppContext context)
        {
            db = context;
        }

        public List<HistoryModel> GetAll()
        {
            return db.History.ToList();
        }

        public HistoryModel GetById(int id)
        {
            return db.History.Find(id);
        }

        public void Create(HistoryModel model)
        {
            db.History.Add(model);
        }

        public void Update(HistoryModel model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            HistoryModel model = db.History.Find(id);
            if (model != null)
                db.History.Remove(model);
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
