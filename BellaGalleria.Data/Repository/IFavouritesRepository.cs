﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Data.Repository
{
    public interface IFavouritesRepository : IRepository<Favourites>
    {
    }

    public class FavouritesRepository : RepositoryBase<Favourites>, IFavouritesRepository
    {
        public FavouritesRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }
    }
}
