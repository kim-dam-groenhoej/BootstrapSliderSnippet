namespace BootstrapSliderSnippet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SliderContext : DbContext
    {
        public SliderContext()
            : base("name=SliderContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<ImageSlide> ImageSlides { get; set; }
    }
}
