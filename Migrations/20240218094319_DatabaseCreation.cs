using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenDataExample.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoPoint2D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoPoint2D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeometryGeometry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeometryGeometry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Welcome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Welcome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultGeometry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeometryId = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultGeometry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultGeometry_GeometryGeometry_GeometryId",
                        column: x => x.GeometryId,
                        principalTable: "GeometryGeometry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultGeometry_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeometryId = table.Column<int>(type: "int", nullable: false),
                    Huisnr = table.Column<long>(type: "bigint", nullable: false),
                    Karakter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eigenaar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capaciteit = table.Column<long>(type: "bigint", nullable: false),
                    Openbaar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ondergrond = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bestemming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naamid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bezettingsinfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bronid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Betrokkenadressen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestampbron = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    GeoPoint2DId = table.Column<int>(type: "int", nullable: false),
                    WelcomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_GeoPoint2D_GeoPoint2DId",
                        column: x => x.GeoPoint2DId,
                        principalTable: "GeoPoint2D",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_ResultGeometry_GeometryId",
                        column: x => x.GeometryId,
                        principalTable: "ResultGeometry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Welcome_WelcomeId",
                        column: x => x.WelcomeId,
                        principalTable: "Welcome",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_GeoPoint2DId",
                table: "Result",
                column: "GeoPoint2DId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_GeometryId",
                table: "Result",
                column: "GeometryId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_WelcomeId",
                table: "Result",
                column: "WelcomeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultGeometry_GeometryId",
                table: "ResultGeometry",
                column: "GeometryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultGeometry_PropertiesId",
                table: "ResultGeometry",
                column: "PropertiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "GeoPoint2D");

            migrationBuilder.DropTable(
                name: "ResultGeometry");

            migrationBuilder.DropTable(
                name: "Welcome");

            migrationBuilder.DropTable(
                name: "GeometryGeometry");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
