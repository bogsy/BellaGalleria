using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BellaGalleria.Model.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ArtistId { get; set; }

        private DateTime? createdAt;
        
        public DateTime Created
        {
            get { return createdAt ?? DateTime.Now; }
            set { createdAt = value; } 
        }

        public string ImageUrl { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual Artist Artist { get; set; } 
    }
}
