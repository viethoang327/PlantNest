using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNestApp.Migrations
{
    public partial class UpdateTypeInCate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "newsCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "newsCategories");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "categories");
        }
    }
}
