using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieCharactersEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Age", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, 12, null, "Sophie Hatter", "Female", "https://static.wikia.nocookie.net/studio-ghibli/images/5/55/Starlight_Sophie.jpg/revision/latest?cb=20210708011122" },
                    { 2, null, "Fire Demon", "Calcifer", null, "https://i.pinimg.com/736x/2d/ba/9a/2dba9a559e6b0a04f5086324ca96fe75.jpg" },
                    { 3, 10, "Sen", "Chihiro Ogino", "Female", "https://static.wikia.nocookie.net/p__/images/9/90/Chihiro_cropped.jpg/revision/latest?cb=20220309165348&path-prefix=protagonist" },
                    { 4, null, "Haku", "Spirit of the Kohaku River", null, "https://static.wikia.nocookie.net/studio-ghibli/images/3/37/Haku_Dragon_form.jpeg/revision/latest/scale-to-width-down/894?cb=20170904233228" },
                    { 5, null, "Kaonashi", "No-Face", null, null },
                    { 6, 10, null, "Satsuki Kusakabe", null, "https://static.wikia.nocookie.net/disney/images/b/b9/Satsuki.jpg/revision/latest?cb=20140725154339" },
                    { 7, 3000, null, "Totoro", "Male", "https://static.wikia.nocookie.net/studio-ghibli/images/d/df/Totoro_in_the_rain.png/revision/latest/scale-to-width-down/350?cb=20200831205004" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Studio Ghibli Inc. is a Japanese animation film studio based in Koganei, Tokyo. The studio is best known for its animated films and has also produced several short films, television commercials, and a television movie.", "Studio Ghibli" },
                    { 2, "Madhouse Inc. is a Japanese animation studio founded in 1972 by former Mushi Pro animators, including Masao Maruyama, Osamu Dezaki, Rintaro, and Yoshiaki Kawajiri.", "Madhouse" },
                    { 3, "Toei Animation Co., Ltd. is a Japanese animation studio controlled primarily by its namesake Toei Company. It has created a number of television series and movies and has adapted Japanese comics as animated series, many of which are popular around the world.", "Toei Animation" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 6, "Mamoru Oshii", null, "Anime", null, 1995, "Ghost in the Shell", null },
                    { 1, "Hayao Miyazaki", 1, "Anime", "https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/Howls-moving-castleposter.jpg/220px-Howls-moving-castleposter.jpg", 2004, "Howl's Moving Castle", "https://www.youtube.com/watch?v=iwROgK94zcM" },
                    { 2, "Hayao Miyazaki", 1, "Anime", "https://upload.wikimedia.org/wikipedia/en/thumb/d/db/Spirited_Away_Japanese_poster.png/220px-Spirited_Away_Japanese_poster.png", 2001, "Spirited Away", "https://www.youtube.com/watch?v=ByXuk9QqQkk" },
                    { 3, "Hayao Miyazaki", 1, "Anime", "https://upload.wikimedia.org/wikipedia/en/thumb/0/02/My_Neighbor_Totoro_-_Tonari_no_Totoro_%28Movie_Poster%29.jpg/220px-My_Neighbor_Totoro_-_Tonari_no_Totoro_%28Movie_Poster%29.jpg", 1988, "My Neighbor Totoro", "https://www.youtube.com/watch?v=92a7Hj0ijLs" },
                    { 4, "Hayao Miyazaki", 1, "Anime", null, 2002, "Mei and the Kittenbus", "https://www.youtube.com/watch?v=92a7Hj0ijLs" },
                    { 5, "Adam Wingard", 2, "Anime", null, 2017, "Death Note", null }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 3 },
                    { 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_CharacterId",
                table: "CharacterMovie",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Franchise");
        }
    }
}
