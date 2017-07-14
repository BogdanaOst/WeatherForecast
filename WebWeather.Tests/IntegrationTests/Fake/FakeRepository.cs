using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebWeather.Tests.IntegrationTests.Fake
{
    public class FakeRepository<T> : IRepository<T> where T:class, IEntity
    {
        public readonly List<T> Data;
        public FakeRepository(params T[] data)
        {
            Data = new List<T>(data);
        }

        public List<T> GetAll()
        {
            return Data;
        }

        public T GetById(int id)
        {
            return Data.FirstOrDefault(x=>x.Id == id);
        }

        public void Create(T model)
        {
            Data.Add(model);
        }

        public void Update(T model)
        {
            
        }

        public void Delete(int id)
        {
           
        }
        public void Save()
        {
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Dispose();
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

