using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class createtablesanpham : Migration
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

            migrationBuilder.CreateTable(
                name: "P_SanPham",
                columns: table => new
                {
                    MA_SAN_PHAM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TEN_SAN_PHAM = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: false),
                    MO_TA = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    GIA_BAN = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GIA_CHIET_KHAU = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MA_DANH_MUC = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MA_G_STORE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NGAY_DANG_KI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NGAY_DUYET = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_SanPham", x => x.MA_SAN_PHAM);
                },
                comment: "bảng sản phẩm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_SanPham");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);
        }
    }
}
