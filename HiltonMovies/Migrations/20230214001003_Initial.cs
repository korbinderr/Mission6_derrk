using Microsoft.EntityFrameworkCore.Migrations;

namespace HiltonMovies.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<short>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lent = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.MovieID);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieID", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 1, "Action/Adventure", "Troy Duffy", true, "", "", "R", "Boondock Saints, The", (short)1999 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieID", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 2, "Action/Adventure", "Christopher Nolan", false, "", "", "PG-13", "Dark Knight Rises, The", (short)2012 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieID", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 3, "Action/Adventure", "John McTiernan", true, "", "", "R", "Die Hard", (short)1988 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
