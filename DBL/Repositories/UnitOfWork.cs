using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBL.Interfaces;
using DBL.Models;


namespace DBL.Repositories
{
    
    public class UnitOfWork : IDisposable
    {
        private DataContext db { get; }

        public UnitOfWork()
        {
            this.db = new DataContext();
        }

        public Dictionary<Type, object> Repos = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {
            if (Repos.Keys.Contains(typeof(T)))
                return Repos[typeof(T)] as IRepository<T>;
            IRepository<T> repo = new GenericRepository<T>(db);
            Repos.Add(typeof(T), repo);
            return repo;
        }


        //do anlizy 
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}