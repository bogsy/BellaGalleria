using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace BellaGalleria.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        T GetById(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
       // IPagedList<T> GetPage();
    }
}
