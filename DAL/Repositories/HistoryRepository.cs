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

        public async Task<List<HistoryModel>> GetAllAsync()
        {
            return await db.History.ToListAsync();
        }

        public async Task<HistoryModel> GetByIdAsync(int id)
        {
            return await db.History.FindAsync(id);
        }

        public async Task CreateAsync(HistoryModel model)
        {
           await Task.Run(()=>db.History.Add(model)).ConfigureAwait(false);
        }

        public void Update(HistoryModel model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            HistoryModel model = await db.History.FindAsync(id);
            if (model != null)
                db.History.Remove(model);
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
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
