using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace DBL.Interfaces
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly IDataContext dbContext;

        public Repository(IDataContext dataContext)
        {
            dbContext = dataContext;
        }

        public List<T> GetAll()
        {
            return dbContext.GetDbSet<T>().ToList();
        }

        public T GetById(int id)
        {
            return this.dbContext.GetDbSet<T>().Find(id);
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}