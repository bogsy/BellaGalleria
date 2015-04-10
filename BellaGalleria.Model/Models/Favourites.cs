using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaGalleria.Model.Models
{
    public class Favourites
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Artwork> Artworks { get; set; }
    }
}
