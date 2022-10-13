using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKutuphane.Migrations
{
    public partial class GenresModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenresGenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "Books",
                newName: "GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenresGenreId",
                table: "Books",
                newName: "IX_Books_GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "Books",
                newName: "GenresGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenresId",
                table: "Books",
                newName: "IX_Books_GenresGenreId");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenresGenreId",
                table: "Books",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
