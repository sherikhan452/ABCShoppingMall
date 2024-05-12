namespace ABCShoppingMall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class re : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodCourts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(nullable: false),
                        Food_Detail = c.String(),
                        Image = c.String(),
                        Items = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(nullable: false),
                        Gallery_Detail = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MultiplexId = c.Int(nullable: false),
                        SeatsAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Multiplexes", t => t.MultiplexId, cascadeDelete: true)
                .Index(t => t.MultiplexId);
            
            CreateTable(
                "dbo.Multiplexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShopName = c.String(nullable: false),
                        Shop_Detail = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        CardDetails = c.String(),
                        IsBooked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "MultiplexId", "dbo.Multiplexes");
            DropIndex("dbo.Tickets", new[] { "MovieId" });
            DropIndex("dbo.Movies", new[] { "MultiplexId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.ShoppingCenters");
            DropTable("dbo.Multiplexes");
            DropTable("dbo.Movies");
            DropTable("dbo.Galleries");
            DropTable("dbo.FoodCourts");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.AdminLogins");
        }
    }
}
