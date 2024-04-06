using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRate2.Migrations
{
    /// <inheritdoc />
    public partial class OtelResimEkle3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtelResimOtelId",
                table: "Resimler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OtelResimOtelId",
                table: "Resimler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
