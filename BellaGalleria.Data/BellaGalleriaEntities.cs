using System.Data.Entity;
using System;
using System.Collections.Generic;
using BellaGalleria.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BellaGalleria.Data
{
    public class BellaGalleriaEntities : IdentityDbContext<ApplicationUser>
    {
        public BellaGalleriaEntities()
            : base("BellaGalleriaEntities")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BellaGalleriaEntities>());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Favourites> Favourites { get; set; } 

        public virtual void Commit()
        {
            base.SaveChanges();
        }

    }
}
