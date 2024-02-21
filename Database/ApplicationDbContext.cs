using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpenDataExample.Models;

namespace OpenDataExample.Database;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext(DbContextOptions options)
    : base(options)
    {
    }

    public virtual DbSet<GeoPoint2D> GeoPoint2Ds { get; set; }

    public virtual DbSet<GeometryGeometry> GeometryGeometries { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<ResultGeometry> ResultGeometries { get; set; }

    public virtual DbSet<Welcome> Welcomes { get; set; }

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,3025;Initial Catalog=OpenDataExample;Persist Security Info=True;User ID=sa;Password=ZwarteRidder007;Pooling=False;Encrypt=True;Trust Server Certificate=True");
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeoPoint2D>(entity =>
        {
            entity.ToTable("GeoPoint2D");
        });

        modelBuilder.Entity<GeometryGeometry>(entity =>
        {
            entity.ToTable("GeometryGeometry");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.ToTable("Result");

            entity.HasIndex(e => e.GeoPoint2Did, "IX_Result_GeoPoint2DId");

            entity.HasIndex(e => e.GeometryId, "IX_Result_GeometryId");

            entity.HasIndex(e => e.WelcomeId, "IX_Result_WelcomeId");

            entity.Property(e => e.GeoPoint2Did).HasColumnName("GeoPoint2DId");

            entity.HasOne(d => d.GeoPoint2D).WithMany(p => p.Results).HasForeignKey(d => d.GeoPoint2Did);

            entity.HasOne(d => d.Geometry).WithMany(p => p.Results).HasForeignKey(d => d.GeometryId);

            entity.HasOne(d => d.Welcome).WithMany(p => p.Results).HasForeignKey(d => d.WelcomeId);
        });

        modelBuilder.Entity<ResultGeometry>(entity =>
        {
            entity.ToTable("ResultGeometry");

            entity.HasIndex(e => e.GeometryId, "IX_ResultGeometry_GeometryId");

            entity.HasIndex(e => e.PropertiesId, "IX_ResultGeometry_PropertiesId");

            entity.HasOne(d => d.Geometry).WithMany(p => p.ResultGeometries).HasForeignKey(d => d.GeometryId);

            entity.HasOne(d => d.Properties).WithMany(p => p.ResultGeometries).HasForeignKey(d => d.PropertiesId);
        });

        modelBuilder.Entity<Welcome>(entity =>
        {
            entity.ToTable("Welcome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
