﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace DBL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();    
        T Insert(T obj);
        void Delete(int id);
        void Edit(T obj);
        T FindById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Save();

    }
}
