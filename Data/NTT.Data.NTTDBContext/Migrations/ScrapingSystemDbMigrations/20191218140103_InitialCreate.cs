using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NTT.Data.NTTDBContext.Migrations.ScrapingSystemDbMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScrapingConfig",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateById = table.Column<long>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateById = table.Column<long>(nullable: true),
                    ConfigData = table.Column<string>(nullable: true),
                    Business = table.Column<long>(nullable: false),
                    QueueKey = table.Column<string>(nullable: true),
                    StorageAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapingConfig", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrapingConfig");
        }
    }
}
