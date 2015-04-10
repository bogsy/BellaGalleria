using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BellaGalleria.Model.Models;
using BellaGalleria.ViewModels;

namespace BellaGalleria.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Artwork, ArtworkFormViewModel>();
        }
    }
}