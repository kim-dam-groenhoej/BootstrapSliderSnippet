namespace BootstrapSliderSnippet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedrequried : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageSlides", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ImageSlides", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageSlides", "ImageUrl", c => c.String(nullable: false));
            DropColumn("dbo.ImageSlides", "Discriminator");
        }
    }
}
