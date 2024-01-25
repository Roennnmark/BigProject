using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthYear = table.Column<string>(type: "varchar(10)", nullable: false),
                    BirthMonth = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BirthDay = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentClub = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FirstClub = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nationality = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    FootballClubId = table.Column<int>(type: "int", nullable: false),
                    NationalitiesId = table.Column<int>(type: "int", nullable: false),
                    BirthDatesId = table.Column<int>(type: "int", nullable: false),
                    PositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_BirthDates_BirthDatesId",
                        column: x => x.BirthDatesId,
                        principalTable: "BirthDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballClubs_FootballClubId",
                        column: x => x.FootballClubId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_Nationalities_NationalitiesId",
                        column: x => x.NationalitiesId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_BirthDatesId",
                table: "FootballPlayers",
                column: "BirthDatesId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_Email",
                table: "FootballPlayers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballClubId",
                table: "FootballPlayers",
                column: "FootballClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_NationalitiesId",
                table: "FootballPlayers",
                column: "NationalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_PositionsId",
                table: "FootballPlayers",
                column: "PositionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "BirthDates");

            migrationBuilder.DropTable(
                name: "FootballClubs");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
