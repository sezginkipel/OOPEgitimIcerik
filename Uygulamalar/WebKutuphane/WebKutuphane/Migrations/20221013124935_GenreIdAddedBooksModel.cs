using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKutuphane.Migrations
{
    public partial class GenreIdAddedBooksModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Books");
        }
    }
}
