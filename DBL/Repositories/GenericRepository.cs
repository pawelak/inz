using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace DBL.Interfaces
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDataContext _dbContext;
        private readonly IDbSet<T> _objectSet;

        public GenericRepository(IDataContext dataContext)
        {
            this._dbContext = dataContext;
            this._objectSet = _dbContext.GetDbSet<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _objectSet.AsEnumerable();
        }

        public virtual T Insert(T obj)
        {
            _objectSet.Add(obj);
            this.Save();
            return obj;
        }

        public virtual void Edit(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            Save();
        }

        public virtual void Delete(int id)
        {
            var obj = FindById(id);
            _dbContext.Entry(obj).State = EntityState.Deleted;
            Save();
        }

        public T FindById(int id)
        {
            return _objectSet.Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _objectSet.Where(predicate);
            return query;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}