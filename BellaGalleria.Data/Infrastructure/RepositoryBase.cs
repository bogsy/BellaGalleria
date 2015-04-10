using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BellaGalleria.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private BellaGalleriaEntities _datacontext;
        private readonly IDbSet<T> _dbSet;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected BellaGalleriaEntities DataContext
        {
            get { return _datacontext ?? (_datacontext =  DatabaseFactory.Get()); }
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public virtual void Delete(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> entities = _dbSet.Where(expression).AsEnumerable();
            foreach (T entity in entities)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
