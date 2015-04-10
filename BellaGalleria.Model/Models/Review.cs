using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaGalleria.Model.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public string ReviewerName { get; set; }
    }
}
