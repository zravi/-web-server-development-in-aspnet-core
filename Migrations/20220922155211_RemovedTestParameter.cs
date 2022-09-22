using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersEFCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTestParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestParameter",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestParameter",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
