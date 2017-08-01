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

        public async Task<List<SelectedCity>> GetAllAsync()
        {
            return await db.SelectedCities.ToListAsync();
        }

        public async Task <SelectedCity> GetByIdAsync(int id)
        {
            return await db.SelectedCities.FindAsync(id);
        }

        public async Task CreateAsync(SelectedCity model)
        {
            await Task.Run(() => db.SelectedCities.Add(model)).ConfigureAwait(false);
        }

        public void Update(SelectedCity model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            SelectedCity model = await db.SelectedCities.FindAsync(id);
            if (model != null)
                db.SelectedCities.Remove(model);
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
