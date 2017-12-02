using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBL.Interfaces;
using DBL.Models;


namespace DBL.Repositories
{
    
    public class UnitOfWork : IDisposable
    {//c++ abits with variables ;d 
        private DataContext Db { get; }
        public Dictionary<Type, object> Repos = new Dictionary<Type, object>();
        private bool _disposed;

        public UnitOfWork()
        {
            this.Db = new DataContext();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (Repos.Keys.Contains(typeof(T)))
                return Repos[typeof(T)] as IRepository<T>;
            IRepository<T> repo = new GenericRepository<T>(Db);
            Repos.Add(typeof(T), repo);
            return repo;
        }


        //do anlizy 
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //dispose managed resources todo 
                }
            }
            //dispose unmanaged resources todo
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}