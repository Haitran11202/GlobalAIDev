using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class xoakhoachinhctdonhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_ChiTietDonHang_P_DonHang_MA_DON_HANG",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_P_ChiTietDonHang_P_SanPham_MA_SAN_PHAM",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_P_ChiTietDonHang",
                table: "P_ChiTietDonHang");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MA_DON_HANG",
                table: "P_ChiTietDonHang",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "MA_DON_HANG",
                table: "P_ChiTietDonHang",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_P_ChiTietDonHang",
                table: "P_ChiTietDonHang",
                column: "MA_DON_HANG");

            migrationBuilder.AddForeignKey(
                name: "FK_P_ChiTietDonHang_P_DonHang_MA_DON_HANG",
                table: "P_ChiTietDonHang",
                column: "MA_DON_HANG",
                principalTable: "P_DonHang",
                principalColumn: "MA_DON_HANG",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_ChiTietDonHang_P_SanPham_MA_SAN_PHAM",
                table: "P_ChiTietDonHang",
                column: "MA_SAN_PHAM",
                principalTable: "P_SanPham",
                principalColumn: "MA_SAN_PHAM",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
