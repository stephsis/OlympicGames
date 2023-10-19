using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicGames.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "in", "Indoor" },
                    { "out", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "GameName" },
                values: new object[,]
                {
                    { "para", "Paralympics" },
                    { "sum", "Summer" },
                    { "wint", "Winter" },
                    { "you", "Youth" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "CountryName", "FlagImage", "GameID" },
                values: new object[,]
                {
                    { "bra", "out", "Brazil", "bra.png", "sum" },
                    { "can", "in", "Canada", "can.png", "wint" },
                    { "fra", "in", "France", "fra.png", "you" },
                    { "gb", "in", "Great Britain", "gb.png", "wint" },
                    { "jam", "in", "Jamaica", "jam.png", "wint" },
                    { "net", "out", "Netherlands", "net.png", "sum" },
                    { "por", "out", "Portugal", "por.png", "you" },
                    { "rus", "in", "Russia", "rus.png", "you" },
                    { "swe", "in", "Sweden", "swe.png", "wint" },
                    { "tha", "in", "Thailand", "tha.png", "para" },
                    { "ukr", "in", "Ukraine", "ukr.png", "para" },
                    { "uru", "in", "Uruguay", "uru.png", "para" },
                    { "usa", "out", "USA", "usa.png", "sum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
