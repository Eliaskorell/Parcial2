
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Canciones> Canciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\databases\\Musica.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canciones>()
                .HasOne(c => c.Artista)
                .WithMany(a => a.Canciones)
                .HasForeignKey(c => c.ArtistaId);
        }
    }
}