using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace DBL.Interfaces
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDataContext _dbContext;
        readonly IDbSet<T> _objectSet;

        public GenericRepository(IDataContext dataContext)
        {
            this._dbContext = dataContext;
            this._objectSet = _dbContext.GetDbSet<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _objectSet.AsEnumerable();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _objectSet.ToListAsync();
        }

        public virtual T GetById(int id)
        {
            return _objectSet.Find(id);
        }

        public virtual T Insert(T obj)
        {
            _objectSet.Add(obj);
            this.Save();
            return obj;
        }

        public virtual T Update(T obj)
        {
            _objectSet.AddOrUpdate(obj);
            return obj;
        }

        public virtual void Delete(T obj)
        {
            _objectSet.Remove(obj);
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}