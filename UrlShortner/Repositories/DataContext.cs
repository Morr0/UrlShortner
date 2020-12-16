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
        public DbSet<ShortcutView> ShortcutView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shortcut>()
                .HasKey(x => x.ShortendUrl);
            modelBuilder.Entity<Shortcut>()
                .HasIndex(x => x.OriginalUrl);
            modelBuilder.Entity<Shortcut>()
                .HasIndex(x => x.Views);

            modelBuilder.Entity<ShortcutView>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ShortcutView>()
                .HasOne(x => x.Shortcut)
                .WithMany(x => x.ShortcutViews)
                .HasForeignKey(x => x.ShortendUrl);
        }
    }
}