using Microsoft.EntityFrameworkCore.Migrations;

namespace NTT.Data.NTTDBContext.Migrations.TrackingNpgDBMigrations
{
    public partial class DefineDrawingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DrawingData",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DrawingData");
        }
    }
}
