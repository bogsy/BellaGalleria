using System.Collections.Generic;
using System.Data.Entity;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Data
{
    class BellaGalleriaSampleData 
    {
        public static void Seed(BellaGalleriaEntities context)
        {
            new List<Category>
            {
                new Category {Name = "Ankara"},
                new Category {Name = "Beads"},
                new Category {Name = "Bags"},
                new Category {Name = "Art"},
                new Category {Name = "Painting"},
                new Category {Name = "Watercolour"},
                new Category {Name = "Necklace"},
                new Category {Name = "Accessories"},
                new Category {Name = "Dresses"},
                new Category {Name = "Skirts"},
                new Category {Name = "Shirts"},
                new Category {Name = "Kente"},
                new Category {Name = "African Print"},
                new Category {Name = "Headbands"}
            }.ForEach(c => context.Categories.Add(c));

            context.Commit();
        }
    }
}
