﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenDataExample.Database;

#nullable disable

namespace OpenDataExample.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240218094319_DatabaseCreation")]
    partial class DatabaseCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OpenDataExample.Models.GeoPoint2D", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Lat")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "lat");

                    b.Property<double>("Lon")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "lon");

                    b.HasKey("Id");

                    b.ToTable("GeoPoint2D");

                    b.HasAnnotation("Relational:JsonPropertyName", "geo_point_2d");
                });

            modelBuilder.Entity("OpenDataExample.Models.GeometryGeometry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "coordinates");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.HasKey("Id");

                    b.ToTable("GeometryGeometry");

                    b.HasAnnotation("Relational:JsonPropertyName", "geometry");
                });

            modelBuilder.Entity("OpenDataExample.Models.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Properties");

                    b.HasAnnotation("Relational:JsonPropertyName", "properties");
                });

            modelBuilder.Entity("OpenDataExample.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bestemming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "bestemming");

                    b.Property<string>("Betrokkenadressen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "betrokkenadressen");

                    b.Property<string>("Bezettingsinfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "bezettingsinfo");

                    b.Property<string>("Bronid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "bronid");

                    b.Property<long>("Capaciteit")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "capaciteit");

                    b.Property<string>("Eigenaar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "eigenaar");

                    b.Property<int>("GeoPoint2DId")
                        .HasColumnType("int");

                    b.Property<int>("GeometryId")
                        .HasColumnType("int");

                    b.Property<long>("Huisnr")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "huisnr");

                    b.Property<string>("Karakter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "karakter");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "naam");

                    b.Property<string>("Naamid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "naamid");

                    b.Property<string>("Ondergrond")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "ondergrond");

                    b.Property<string>("Openbaar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "openbaar");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "status");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "straat");

                    b.Property<DateTimeOffset>("Timestampbron")
                        .HasColumnType("datetimeoffset")
                        .HasAnnotation("Relational:JsonPropertyName", "timestampbron");

                    b.Property<string>("Urid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "urid");

                    b.Property<int?>("WelcomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeoPoint2DId");

                    b.HasIndex("GeometryId");

                    b.HasIndex("WelcomeId");

                    b.ToTable("Result");

                    b.HasAnnotation("Relational:JsonPropertyName", "results");
                });

            modelBuilder.Entity("OpenDataExample.Models.ResultGeometry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GeometryId")
                        .HasColumnType("int");

                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.HasKey("Id");

                    b.HasIndex("GeometryId");

                    b.HasIndex("PropertiesId");

                    b.ToTable("ResultGeometry");

                    b.HasAnnotation("Relational:JsonPropertyName", "geometry");
                });

            modelBuilder.Entity("OpenDataExample.Models.Welcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("TotalCount")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "total_count");

                    b.HasKey("Id");

                    b.ToTable("Welcome");
                });

            modelBuilder.Entity("OpenDataExample.Models.Result", b =>
                {
                    b.HasOne("OpenDataExample.Models.GeoPoint2D", "GeoPoint2D")
                        .WithMany()
                        .HasForeignKey("GeoPoint2DId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenDataExample.Models.ResultGeometry", "Geometry")
                        .WithMany()
                        .HasForeignKey("GeometryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenDataExample.Models.Welcome", null)
                        .WithMany("Results")
                        .HasForeignKey("WelcomeId");

                    b.Navigation("GeoPoint2D");

                    b.Navigation("Geometry");
                });

            modelBuilder.Entity("OpenDataExample.Models.ResultGeometry", b =>
                {
                    b.HasOne("OpenDataExample.Models.GeometryGeometry", "Geometry")
                        .WithMany()
                        .HasForeignKey("GeometryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenDataExample.Models.Properties", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Geometry");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("OpenDataExample.Models.Welcome", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
