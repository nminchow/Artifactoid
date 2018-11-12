using Microsoft.EntityFrameworkCore.Migrations;

namespace Artifact.Migrations
{
    public partial class DisplaySettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplaySetting",
                table: "Guilds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplaySetting",
                table: "Guilds");
        }
    }
}
