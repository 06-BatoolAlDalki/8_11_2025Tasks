using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication57.Data.Migrations
{
    /// <inheritdoc />
    public partial class Todaytask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoryNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supplyNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryNewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplyNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supplyNews_categoryNews_CategoryNewId",
                        column: x => x.CategoryNewId,
                        principalTable: "categoryNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplyNewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferNews_supplyNews_SupplyNewId",
                        column: x => x.SupplyNewId,
                        principalTable: "supplyNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferNews_SupplyNewId",
                table: "OfferNews",
                column: "SupplyNewId");

            migrationBuilder.CreateIndex(
                name: "IX_supplyNews_CategoryNewId",
                table: "supplyNews",
                column: "CategoryNewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferNews");

            migrationBuilder.DropTable(
                name: "supplyNews");

            migrationBuilder.DropTable(
                name: "categoryNews");
        }
    }
}
