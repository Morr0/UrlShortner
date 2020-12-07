using Microsoft.EntityFrameworkCore;
using UrlShortner.Models;

namespace UrlShortner.Repositories
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Shortcut> Shortcut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shortcut>()
                .HasIndex(x => x.OriginalUrl);

            modelBuilder.Entity<Shortcut>()
                .HasIndex(x => x.Views);
        }
    }
}