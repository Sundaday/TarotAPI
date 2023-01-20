using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarotAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNaming2namethenid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersId",
                table: "CharacterTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Teams_TeamsId",
                table: "CharacterTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_IdUser",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Guilds_IdGuild",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdGuild",
                table: "Users",
                newName: "GuildId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdGuild",
                table: "Users",
                newName: "IX_Users_GuildId");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Teams",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_IdUser",
                table: "Teams",
                newName: "IX_Teams_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Guilds_GuildId",
                table: "Users",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Characteres_CharactersCharacterId",
                table: "CharacterTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTeam_Teams_TeamsTeamId",
                table: "CharacterTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Guilds_GuildId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GuildId",
                table: "Users",
                newName: "IdGuild");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GuildId",
                table: "Users",
                newName: "IX_Users_IdGuild");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Teams",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                newName: "IX_Teams_IdUser");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_IdUser",
                table: "Teams",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Guilds_IdGuild",
                table: "Users",
                column: "IdGuild",
                principalTable: "Guilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
