using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarotAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Teams",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                newName: "IX_Teams_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_IdUser",
                table: "Teams",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_IdUser",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Teams",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_IdUser",
                table: "Teams",
                newName: "IX_Teams_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
