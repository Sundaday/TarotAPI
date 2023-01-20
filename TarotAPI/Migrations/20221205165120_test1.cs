using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarotAPI.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTeams",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WeaponElement",
                table: "Characteres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalTeams",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WeaponElement",
                table: "Characteres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
