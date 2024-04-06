using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRate2.Migrations
{
    /// <inheritdoc />
    public partial class OtelResimEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cevaplar_Kullanicilar_kullanicilarId",
                table: "Cevaplar");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Cevaplar");

            migrationBuilder.RenameColumn(
                name: "kullanicilarId",
                table: "Cevaplar",
                newName: "KullanicilarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cevaplar_kullanicilarId",
                table: "Cevaplar",
                newName: "IX_Cevaplar_KullanicilarId");

            migrationBuilder.CreateTable(
                name: "Resimler",
                columns: table => new
                {
                    OtelResimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelResimOtelId = table.Column<int>(type: "int", nullable: false),
                    OtelId = table.Column<int>(type: "int", nullable: false),
                    OtelResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimler", x => x.OtelResimId);
                    table.ForeignKey(
                        name: "FK_Resimler_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "OtelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_OtelId",
                table: "Resimler",
                column: "OtelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cevaplar_Kullanicilar_KullanicilarId",
                table: "Cevaplar",
                column: "KullanicilarId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cevaplar_Kullanicilar_KullanicilarId",
                table: "Cevaplar");

            migrationBuilder.DropTable(
                name: "Resimler");

            migrationBuilder.RenameColumn(
                name: "KullanicilarId",
                table: "Cevaplar",
                newName: "kullanicilarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cevaplar_KullanicilarId",
                table: "Cevaplar",
                newName: "IX_Cevaplar_kullanicilarId");

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Cevaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cevaplar_Kullanicilar_kullanicilarId",
                table: "Cevaplar",
                column: "kullanicilarId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
