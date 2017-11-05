using System;
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
        Task<ICollection<T>> GetAllAsync();
        T GetById(int id);
        T Insert(T obj);
        T Update(T obj);
        void Delete(T obj);

    }
}
