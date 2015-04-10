using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Data.Repository
{
    public interface IArtworkRepository : IRepository<Artwork>
    {
    }

    public class ArtworkRepository : RepositoryBase<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }
    }
}
