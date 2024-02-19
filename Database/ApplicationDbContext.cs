using Microsoft.EntityFrameworkCore;
using OpenDataExample.Models;
using System.Text.Json;

namespace OpenDataExample.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<Prize> Prizes { get; set; } // Niet expliciet nodig
        public DbSet<Welcome> Welcome { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Welcome -> Result -> ResultGeometry -> GeometryGeometry
            //                   -> GeoPoint2D
            modelBuilder.Entity<GeoPoint2D>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<GeometryGeometry>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.Property(p => p.Coordinates)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v,(JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<List<List<List<double>>>>(v, (JsonSerializerOptions)null!));
            });
            modelBuilder.Entity<ResultGeometry>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Result>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Welcome>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
