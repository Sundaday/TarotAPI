using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarotAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNaming4changeCharacterstoCharactersListforbetterview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersId",
                table: "CharacterTeam");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterTeam",
                newName: "CharactersListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersListId",
                table: "CharacterTeam",
                column: "CharactersListId",
                principalTable: "Characteres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersListId",
                table: "CharacterTeam");

            migrationBuilder.RenameColumn(
                name: "CharactersListId",
                table: "CharacterTeam",
                newName: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersId",
                table: "CharacterTeam",
                column: "CharactersId",
                principalTable: "Characteres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
