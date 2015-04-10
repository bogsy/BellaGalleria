using AutoMapper;
using BellaGalleria.Model.Models;
using BellaGalleria.ViewModels;

namespace BellaGalleria.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewMOdelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ArtworkFormViewModel, Artwork>();
        }
    }
}