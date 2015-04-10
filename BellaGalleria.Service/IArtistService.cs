using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Data.Repository;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Service
{
    public interface IArtistService : IServiceManager<Artist>
    {
        void CreateArtist(Artist artist);
        IEnumerable<Artist> GetArtists();
        void SaveArtist();
        Artist GetArtist(int id);
        void EditArtist(Artist artist);
        void DeleteArtist(int id);
    }

    public class ArtistService : BaseServiceManager<Artist>, IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IUnitOfWork _unitofwork;
        public ArtistService(IArtistRepository repository, IUnitOfWork unitofwork) 
            : base(repository, unitofwork)
        {
            _artistRepository = repository;
            _unitofwork = unitofwork;
        }

        public void CreateArtist(Artist artist)
        {
            _artistRepository.Add(artist);
            SaveArtist();
        }

        public IEnumerable<Artist> GetArtists()
        {
            IEnumerable<Artist> artist = _artistRepository.GetAll();
            return artist;
        }

        public void SaveArtist()
        {
            _unitofwork.Commit();
        }

        Artist IArtistService.GetArtist(int id)
        {
            var artist = _artistRepository.GetById(id);
            return artist;
        }

        public void EditArtist(Artist artist)
        {
            _artistRepository.Update(artist);
            SaveArtist();
        }

        public void DeleteArtist(int id)
        {
            var artist = _artistRepository.GetById(id);
            _artistRepository.Delete(artist);
            SaveArtist();
        }
    }
}
