using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameTrackr.Migrations
{
    /// <inheritdoc />
    public partial class Adding_UserLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Users_UserId",
                table: "UserGames");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserGames",
                newName: "UserLibraryId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "UserGames",
                newName: "APIGameId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                newName: "IX_UserGames_UserLibraryId");

            migrationBuilder.CreateTable(
                name: "UserLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLibraries_Users_User_ModelId",
                        column: x => x.User_ModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLibraries_User_ModelId",
                table: "UserLibraries",
                column: "User_ModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_UserLibraries_UserLibraryId",
                table: "UserGames",
                column: "UserLibraryId",
                principalTable: "UserLibraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_UserLibraries_UserLibraryId",
                table: "UserGames");

            migrationBuilder.DropTable(
                name: "UserLibraries");

            migrationBuilder.RenameColumn(
                name: "UserLibraryId",
                table: "UserGames",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "APIGameId",
                table: "UserGames",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGames_UserLibraryId",
                table: "UserGames",
                newName: "IX_UserGames_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Users_UserId",
                table: "UserGames",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
