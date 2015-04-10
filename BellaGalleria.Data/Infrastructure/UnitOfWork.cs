using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaGalleria.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private BellaGalleriaEntities _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFacory)
        {
            _databaseFactory = databaseFacory;
        }

        protected BellaGalleriaEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
