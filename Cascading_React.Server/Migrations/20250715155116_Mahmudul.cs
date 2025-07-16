using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cascading_React.Server.Migrations
{
    /// <inheritdoc />
    public partial class Mahmudul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "United States" },
                    { 2, "Canada" },
                    { 3, "United Kingdom" },
                    { 4, "Australia" },
                    { 5, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "California" },
                    { 2, 1, "Texas" },
                    { 3, 1, "New York" },
                    { 4, 1, "Florida" },
                    { 5, 2, "Ontario" },
                    { 6, 2, "Quebec" },
                    { 7, 2, "British Columbia" },
                    { 8, 3, "England" },
                    { 9, 3, "Scotland" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DivisionId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Los Angeles" },
                    { 2, 1, "San Francisco" },
                    { 3, 1, "San Diego" },
                    { 4, 2, "Houston" },
                    { 5, 2, "Dallas" },
                    { 6, 2, "Austin" },
                    { 7, 3, "New York City" },
                    { 8, 3, "Buffalo" },
                    { 9, 4, "Miami" },
                    { 10, 4, "Orlando" },
                    { 11, 5, "Toronto" },
                    { 12, 5, "Ottawa" },
                    { 13, 6, "Montreal" },
                    { 14, 6, "Quebec City" },
                    { 15, 7, "Vancouver" },
                    { 16, 8, "London" },
                    { 17, 8, "Manchester" },
                    { 18, 9, "Edinburgh" },
                    { 19, 9, "Glasgow" },
                    { 20, 8, "Birmingham" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DivisionId",
                table: "Cities",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CountryId",
                table: "Divisions",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
