using LibraryMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Data
{
    public class Context:DbContext
    {
       
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Library;User ID=sa;pwd=Q1w2e3r4;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
