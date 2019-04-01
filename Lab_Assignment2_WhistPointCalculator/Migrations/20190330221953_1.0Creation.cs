using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_Assignment2_WhistPointCalculator.Migrations
{
    public partial class _10Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GamesId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Started = table.Column<string>(nullable: true),
                    EndedUpdated = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GamesId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRounds",
                columns: table => new
                {
                    GameRoundsId = table.Column<string>(nullable: false),
                    RoundNumber = table.Column<int>(nullable: false),
                    DealerPositionEnded = table.Column<int>(nullable: false),
                    Started = table.Column<int>(nullable: false),
                    GamesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRounds", x => x.GameRoundsId);
                    table.ForeignKey(
                        name: "FK_GameRounds_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "GamesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Games_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Games",
                        principalColumn: "GamesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    GamesId = table.Column<string>(nullable: false),
                    GamePlayersId = table.Column<string>(nullable: false),
                    PlayerPosition = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.GamesId);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "GamesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRoundPlayers",
                columns: table => new
                {
                    GameRoundsId = table.Column<string>(nullable: false),
                    ByePoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoundPlayers", x => x.GameRoundsId);
                    table.ForeignKey(
                        name: "FK_GameRoundPlayers_GameRounds_GameRoundsId",
                        column: x => x.GameRoundsId,
                        principalTable: "GameRounds",
                        principalColumn: "GameRoundsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    GameRoundsId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Soletype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.GameRoundsId);
                    table.ForeignKey(
                        name: "FK_Rounds_GameRounds_GameRoundsId",
                        column: x => x.GameRoundsId,
                        principalTable: "GameRounds",
                        principalColumn: "GameRoundsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoleRoundWinners",
                columns: table => new
                {
                    GameRoundsId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoleRoundWinners", x => x.GameRoundsId);
                    table.ForeignKey(
                        name: "FK_SoleRoundWinners_GameRounds_GameRoundsId",
                        column: x => x.GameRoundsId,
                        principalTable: "GameRounds",
                        principalColumn: "GameRoundsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_PlayerId",
                table: "GamePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRounds_GamesId",
                table: "GameRounds",
                column: "GamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "GameRoundPlayers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "SoleRoundWinners");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "GameRounds");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
