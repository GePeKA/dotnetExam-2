using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Main.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUsername = table.Column<string>(type: "text", nullable: false),
                    OpponentUsername = table.Column<string>(type: "text", nullable: false),
                    CurrentRound = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSessions_Users_CreatorUsername",
                        column: x => x.CreatorUsername,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSessions_Users_OpponentUsername",
                        column: x => x.OpponentUsername,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSessionId = table.Column<long>(type: "bigint", nullable: false),
                    RoundNumber = table.Column<int>(type: "integer", nullable: false),
                    PlayerXUsername = table.Column<string>(type: "text", nullable: false),
                    PlayerOUsername = table.Column<string>(type: "text", nullable: false),
                    WinnerUsername = table.Column<string>(type: "text", nullable: false),
                    CurrentMove = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Users_PlayerOUsername",
                        column: x => x.PlayerOUsername,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Users_PlayerXUsername",
                        column: x => x.PlayerXUsername,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Users_WinnerUsername",
                        column: x => x.WinnerUsername,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MoveNumber = table.Column<short>(type: "smallint", nullable: false),
                    CellIndex = table.Column<short>(type: "smallint", nullable: false),
                    RoundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moves_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_CreatorUsername",
                table: "GameSessions",
                column: "CreatorUsername");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_OpponentUsername",
                table: "GameSessions",
                column: "OpponentUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_RoundId",
                table: "Moves",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_Username",
                table: "Moves",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameSessionId",
                table: "Rounds",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_PlayerOUsername",
                table: "Rounds",
                column: "PlayerOUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_PlayerXUsername",
                table: "Rounds",
                column: "PlayerXUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinnerUsername",
                table: "Rounds",
                column: "WinnerUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
