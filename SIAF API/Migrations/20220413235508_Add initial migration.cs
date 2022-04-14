using Microsoft.EntityFrameworkCore.Migrations;

namespace SIAF_API.Migrations
{
    public partial class Addinitialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetCategories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetCategories", x => x.CategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "GetProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetProducts_GetCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GetCategories",
                        principalColumn: "CategoriesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetProducts_CategoryId",
                table: "GetProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetProducts");

            migrationBuilder.DropTable(
                name: "GetCategories");
        }
    }
}
