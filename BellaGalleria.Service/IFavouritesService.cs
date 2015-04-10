using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Service
{
    public interface IFavouritesService : IServiceManager<Favourites>
    {
    }

    public class FavouritesService : BaseServiceManager<Favourites>
    {
        public FavouritesService(IRepository<Favourites> repository, IUnitOfWork unitofwork) 
            : base(repository, unitofwork)
        {
        }
    }
}
