using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameTrackr.Migrations
{
    /// <inheritdoc />
    public partial class Fixing_Database_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Users_User_ModelId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_User_ModelId",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "User_ModelId",
                table: "UserGames");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Users_UserId",
                table: "UserGames",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Users_UserId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames");

            migrationBuilder.AddColumn<int>(
                name: "User_ModelId",
                table: "UserGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_User_ModelId",
                table: "UserGames",
                column: "User_ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Users_User_ModelId",
                table: "UserGames",
                column: "User_ModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
