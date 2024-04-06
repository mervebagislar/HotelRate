using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRate2.Migrations
{
    /// <inheritdoc />
    public partial class SoruMetniEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoruMetni",
                table: "Sorular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoruMetni",
                table: "Sorular");
        }
    }
}
