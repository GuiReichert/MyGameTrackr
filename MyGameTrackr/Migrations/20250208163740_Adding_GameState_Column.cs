using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameTrackr.Migrations
{
    /// <inheritdoc />
    public partial class Adding_GameState_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "UserGames");
        }
    }
}
