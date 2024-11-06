using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGiay.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiGiay",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGiay", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGiay",
                columns: table => new
                {
                    MaGiay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGiay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KichCo = table.Column<int>(type: "int", nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaLoaiGiay = table.Column<int>(type: "int", nullable: false),
                    LoaiGiayMaLoai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGiay", x => x.MaGiay);
                    table.ForeignKey(
                        name: "FK_ChiTietGiay_LoaiGiay_LoaiGiayMaLoai",
                        column: x => x.LoaiGiayMaLoai,
                        principalTable: "LoaiGiay",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGiay_LoaiGiayMaLoai",
                table: "ChiTietGiay",
                column: "LoaiGiayMaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietGiay");

            migrationBuilder.DropTable(
                name: "LoaiGiay");
        }
    }
}
