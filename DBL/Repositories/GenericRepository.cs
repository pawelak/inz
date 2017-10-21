using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DBL.Interfaces
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDataContext dbContext;
        IDbSet<T> objectSet;

        public GenericRepository(IDataContext dataContext)
        {
            this.dbContext = dataContext;
            this.objectSet = dbContext.GetDbSet<T>();
        }

        public List<T> GetAll()
        {
            return dbContext.GetDbSet<T>().ToList();
        }

        public T GetById(int id)
        {
            return this.dbContext.GetDbSet<T>().Find(id);
        }
        public T GetByPhrase(string phrase)
        {
            return this.dbContext.GetDbSet<T>().Find(phrase);
        }

        public void Insert(T obj)
        {
            this.dbContext.GetDbSet<T>().Add(obj);
            this.dbContext.SaveChanges();
        }

        public void Delete(T obj)
        {
            this.dbContext.GetDbSet<T>().Remove(obj);
        }


    }
}