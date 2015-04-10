using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Data.Repository
{
    public interface IArtistRepository : IRepository<Artist>
    {
    }

    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }
        
    }
}
