using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaGalleria.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private BellaGalleriaEntities _datacontext;

        public BellaGalleriaEntities Get()
        {
            return _datacontext ?? ( _datacontext = new BellaGalleriaEntities()) ;
        }

        protected override void DisposeCore()
        {
            if (_datacontext != null)
                _datacontext.Dispose();
        }
    }
}
