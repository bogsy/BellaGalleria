using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Data.Repository;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Service
{
    public interface IArtworkService : IServiceManager<Artwork>
    {
        void CreateArtwork(Artwork artwork);
        IEnumerable<Artwork> GetArtworks();
        Artwork GetArtwork(int id);
        void EditArtwork(Artwork artwork);
        void DeleteArtwork(Artwork artwork);
        void SaveArtwork();

    }

    public class ArtworkService : BaseServiceManager<Artwork>, IArtworkService
    {
        private readonly IArtworkRepository _artworkrepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArtworkService(IArtworkRepository repository, IUnitOfWork unitofwork) 
            : base(repository, unitofwork)
        {
            _artworkrepository = repository;
            _unitOfWork = unitofwork;
        }

        public void CreateArtwork(Artwork artwork)
        {
            _artworkrepository.Add(artwork);
            SaveArtwork();
        }

        public IEnumerable<Artwork> GetArtworks()
        {
            IEnumerable<Artwork> artworks = _artworkrepository.GetAll();
            return artworks;
        }

        public Artwork GetArtwork(int id)
        {
            Artwork artwork = _artworkrepository.GetById(id);
            return artwork;
        }

        public void EditArtwork(Artwork artwork)
        {
            _artworkrepository.Update(artwork);
            SaveArtwork();
        }

        public void DeleteArtwork(Artwork artwork)
        {
            _artworkrepository.Delete(artwork);
            SaveArtwork();
        }

        public void SaveArtwork()
        {
            _unitOfWork.Commit();
        }
    }
}
