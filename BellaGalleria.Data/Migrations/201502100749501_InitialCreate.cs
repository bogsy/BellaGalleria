namespace BellaGalleria.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        Artist_Id = c.Int(),
                        Favourites_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Favourites", t => t.Favourites_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Favourites_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtworkId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        ReviewerName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artworks", t => t.ArtworkId, cascadeDelete: true)
                .Index(t => t.ArtworkId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CategoryArtworks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Artwork_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Artwork_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artworks", t => t.Artwork_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Artwork_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Artworks", "Favourites_Id", "dbo.Favourites");
            DropForeignKey("dbo.Reviews", "ArtworkId", "dbo.Artworks");
            DropForeignKey("dbo.CategoryArtworks", "Artwork_Id", "dbo.Artworks");
            DropForeignKey("dbo.CategoryArtworks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Artworks", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.CategoryArtworks", new[] { "Artwork_Id" });
            DropIndex("dbo.CategoryArtworks", new[] { "Category_Id" });
            DropIndex("dbo.Favourites", new[] { "CustomerId" });
            DropIndex("dbo.Reviews", new[] { "ArtworkId" });
            DropIndex("dbo.Artworks", new[] { "Favourites_Id" });
            DropIndex("dbo.Artworks", new[] { "Artist_Id" });
            DropTable("dbo.CategoryArtworks");
            DropTable("dbo.Favourites");
            DropTable("dbo.Customers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Categories");
            DropTable("dbo.Artworks");
            DropTable("dbo.Artists");
        }
    }
}
