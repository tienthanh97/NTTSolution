using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NTT.Data.NTTDBContext.Migrations.TrackingNpgDBMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrawingData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateById = table.Column<long>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateById = table.Column<long>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrapingBusiness",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateById = table.Column<long>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateById = table.Column<long>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapingBusiness", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawingData");

            migrationBuilder.DropTable(
                name: "ScrapingBusiness");
        }
    }
}
