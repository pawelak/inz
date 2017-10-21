using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DBL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Delete(T obj);
        T GetByPhrase(string phrase);
    }
}
