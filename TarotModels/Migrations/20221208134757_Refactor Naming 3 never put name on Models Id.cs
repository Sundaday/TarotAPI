using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarotAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNaming3neverputnameonModelsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersCharacterId",
                table: "CharacterTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Teams_TeamsTeamId",
                table: "CharacterTeam");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GuildId",
                table: "Guilds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TeamsTeamId",
                table: "CharacterTeam",
                newName: "TeamsId");

            migrationBuilder.RenameColumn(
                name: "CharactersCharacterId",
                table: "CharacterTeam",
                newName: "CharactersId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterTeam_TeamsTeamId",
                table: "CharacterTeam",
                newName: "IX_CharacterTeam_TeamsId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Characteres",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersId",
                table: "CharacterTeam",
                column: "CharactersId",
                principalTable: "Characteres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTeam_Teams_TeamsId",
                table: "CharacterTeam",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersId",
                table: "CharacterTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Teams_TeamsId",
                table: "CharacterTeam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Guilds",
                newName: "GuildId");

            migrationBuilder.RenameColumn(
                name: "TeamsId",
                table: "CharacterTeam",
                newName: "TeamsTeamId");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterTeam",
                newName: "CharactersCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterTeam_TeamsId",
                table: "CharacterTeam",
                newName: "IX_CharacterTeam_TeamsTeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Characteres",
                newName: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersCharacterId",
                table: "CharacterTeam",
                column: "CharactersCharacterId",
                principalTable: "Characteres",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTeam_Teams_TeamsTeamId",
                table: "CharacterTeam",
                column: "TeamsTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
