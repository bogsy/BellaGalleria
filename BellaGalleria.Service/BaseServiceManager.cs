using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;

namespace BellaGalleria.Service
{
    public abstract class BaseServiceManager<T> : IServiceManager<T> where T : class
    {
        protected readonly IRepository <T> _repository;
        private readonly IUnitOfWork _unitofwork;

        protected BaseServiceManager(IRepository<T> repository, IUnitOfWork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }

        public void Create(T entity)
        {
            _repository.Add(entity);
            SaveChanges();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById(id);
            _repository.Delete(entity);
            SaveChanges();
        }

        public void Update(int id)
        {
            var entity = _repository.GetById(id);
            _repository.Update(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitofwork.Commit();
        }
    }
}
