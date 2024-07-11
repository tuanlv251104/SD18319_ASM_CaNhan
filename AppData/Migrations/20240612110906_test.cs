using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gioHang",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHang", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnhSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaSP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangCungCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoans",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoans", x => x.Username);
                    table.ForeignKey(
                        name: "FK_taiKhoans_gioHang_Username",
                        column: x => x.Username,
                        principalTable: "gioHang",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangCTs_gioHang_Username",
                        column: x => x.Username,
                        principalTable: "gioHang",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangCTs_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDons_taiKhoans_Username",
                        column: x => x.Username,
                        principalTable: "taiKhoans",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDonsCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonsCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDonsCTs_hoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "hoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonsCTs_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCTs_SanPhamId",
                table: "GioHangCTs",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCTs_Username",
                table: "GioHangCTs",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Username",
                table: "hoaDons",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonsCTs_HoaDonId",
                table: "hoaDonsCTs",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonsCTs_SanPhamId",
                table: "hoaDonsCTs",
                column: "SanPhamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangCTs");

            migrationBuilder.DropTable(
                name: "hoaDonsCTs");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropTable(
                name: "sanPhams");

            migrationBuilder.DropTable(
                name: "taiKhoans");

            migrationBuilder.DropTable(
                name: "gioHang");
        }
    }
}
