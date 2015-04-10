using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using BellaGalleria.Model.Models;

namespace BellaGalleria.ViewModels
{
    public class ArtworkFormViewModel
    {
        public int Id { get; set; }
        //public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //[Display(Name = "Image")]
        //[DataType(DataType.ImageUrl)]
        //public string ImageUrl { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        public HttpPostedFileBase Attachment { get; set; }

        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> Categories { get; set; }
        public int? CategoryId { get; set; }
        public int ArtistId { get; set; } 
    }
}