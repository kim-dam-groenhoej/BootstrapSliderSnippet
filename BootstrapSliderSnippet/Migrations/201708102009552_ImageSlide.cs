namespace BootstrapSliderSnippet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageSlide : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageSlides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageSlides");
        }
    }
}
