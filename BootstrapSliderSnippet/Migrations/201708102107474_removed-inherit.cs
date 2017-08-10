namespace BootstrapSliderSnippet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedinherit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ImageSlides", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageSlides", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
