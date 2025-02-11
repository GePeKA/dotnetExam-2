using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaxAllowedRatingAndIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxAllowedRating",
                table: "GameSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_Status_DateTimeCreated",
                table: "GameSessions",
                columns: new[] { "Status", "DateTimeCreated" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameSessions_Status_DateTimeCreated",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "MaxAllowedRating",
                table: "GameSessions");
        }
    }
}
