using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class createTableDonHangandChiTietDonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    MA_DON_HANG = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NGAY_HOAN_THANH = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MA_G_STORE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MA_G_SALER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SO_TIEN = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    HINH_THUC_THANH_TOAN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.MA_DON_HANG);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHangs",
                columns: table => new
                {
                    MA_DON_HANG = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MA_SAN_PHAM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangs", x => x.MA_DON_HANG);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_DonHangs_MA_DON_HANG",
                        column: x => x.MA_DON_HANG,
                        principalTable: "DonHangs",
                        principalColumn: "MA_DON_HANG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_P_SanPham_MA_SAN_PHAM",
                        column: x => x.MA_SAN_PHAM,
                        principalTable: "P_SanPham",
                        principalColumn: "MA_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_MA_SAN_PHAM",
                table: "ChiTietDonHangs",
                column: "MA_SAN_PHAM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
