using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaGalleria.Service
{
    public interface IServiceManager<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Delete(int id);
        void Update(int id);
        void SaveChanges();
    }
}
