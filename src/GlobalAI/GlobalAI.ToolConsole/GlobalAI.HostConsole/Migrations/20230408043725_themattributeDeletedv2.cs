using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class themattributeDeletedv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_DonHangs_MA_DON_HANG",
                table: "ChiTietDonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_P_SanPham_MA_SAN_PHAM",
                table: "ChiTietDonHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHangs",
                table: "DonHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonHangs",
                table: "ChiTietDonHangs");

            migrationBuilder.RenameTable(
                name: "DonHangs",
                newName: "P_DonHang");

            migrationBuilder.RenameTable(
                name: "ChiTietDonHangs",
                newName: "P_ChiTietDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHangs_MA_SAN_PHAM",
                table: "P_ChiTietDonHang",
                newName: "IX_P_ChiTietDonHang_MA_SAN_PHAM");

            migrationBuilder.AlterTable(
                name: "P_DonHang",
                comment: "bảng đơn hàng");

            migrationBuilder.AlterTable(
                name: "P_ChiTietDonHang",
                comment: "bảng chi tiết đơn hàng");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_P_DonHang",
                table: "P_DonHang",
                column: "MA_DON_HANG");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_ChiTietDonHang_P_DonHang_MA_DON_HANG",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_P_ChiTietDonHang_P_SanPham_MA_SAN_PHAM",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_P_DonHang",
                table: "P_DonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_P_ChiTietDonHang",
                table: "P_ChiTietDonHang");

            migrationBuilder.RenameTable(
                name: "P_DonHang",
                newName: "DonHangs");

            migrationBuilder.RenameTable(
                name: "P_ChiTietDonHang",
                newName: "ChiTietDonHangs");

            migrationBuilder.RenameIndex(
                name: "IX_P_ChiTietDonHang_MA_SAN_PHAM",
                table: "ChiTietDonHangs",
                newName: "IX_ChiTietDonHangs_MA_SAN_PHAM");

            migrationBuilder.AlterTable(
                name: "DonHangs",
                oldComment: "bảng đơn hàng");

            migrationBuilder.AlterTable(
                name: "ChiTietDonHangs",
                oldComment: "bảng chi tiết đơn hàng");

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
                table: "DonHangs",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHangs",
                table: "DonHangs",
                column: "MA_DON_HANG");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonHangs",
                table: "ChiTietDonHangs",
                column: "MA_DON_HANG");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_DonHangs_MA_DON_HANG",
                table: "ChiTietDonHangs",
                column: "MA_DON_HANG",
                principalTable: "DonHangs",
                principalColumn: "MA_DON_HANG",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_P_SanPham_MA_SAN_PHAM",
                table: "ChiTietDonHangs",
                column: "MA_SAN_PHAM",
                principalTable: "P_SanPham",
                principalColumn: "MA_SAN_PHAM",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
