using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    public class AnimeContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<AnimeTag> AnimeTags { get; set; }

        public AnimeContext(DbContextOptions<AnimeContext> context)
           : base(context)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeTag>()
                .HasKey(t => new { t.TagId, t.AnimeId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./EntityFrameworkCore.db");
        }
    }
}
