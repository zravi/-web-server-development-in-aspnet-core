using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestParameter",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestParameter",
                table: "Movies");
        }
    }
}
