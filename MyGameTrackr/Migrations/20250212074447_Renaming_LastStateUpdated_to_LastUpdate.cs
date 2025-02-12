using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameTrackr.Migrations
{
    /// <inheritdoc />
    public partial class Renaming_LastStateUpdated_to_LastUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastStateUpdated",
                table: "GameReviews",
                newName: "LastUpdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "GameReviews",
                newName: "LastStateUpdated");
        }
    }
}
