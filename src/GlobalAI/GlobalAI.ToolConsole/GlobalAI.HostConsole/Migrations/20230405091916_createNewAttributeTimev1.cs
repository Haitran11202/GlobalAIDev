using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class createNewAttributeTimev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEMO_PRODUCT");

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

            migrationBuilder.AddColumn<string>(
                name: "CREATED_BY",
                table: "P_SanPham",
                type: "VARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_DATE",
                table: "P_SanPham",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DELETED_BY",
                table: "P_SanPham",
                type: "VARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DELETED_DATE",
                table: "P_SanPham",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MODIFIED_BY",
                table: "P_SanPham",
                type: "VARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "P_SanPham",
                type: "DATE",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_BY",
                table: "P_SanPham");

            migrationBuilder.DropColumn(
                name: "CREATED_DATE",
                table: "P_SanPham");

            migrationBuilder.DropColumn(
                name: "DELETED_BY",
                table: "P_SanPham");

            migrationBuilder.DropColumn(
                name: "DELETED_DATE",
                table: "P_SanPham");

            migrationBuilder.DropColumn(
                name: "MODIFIED_BY",
                table: "P_SanPham");

            migrationBuilder.DropColumn(
                name: "MODIFIED_DATE",
                table: "P_SanPham");

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

            migrationBuilder.CreateTable(
                name: "DEMO_PRODUCT",
                columns: table => new
                {
                    PRODUCT_RECORD_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    MANUFACTURER = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    PRICE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRODUCT_ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEMO_PRODUCT", x => x.PRODUCT_RECORD_ID);
                },
                comment: "Demo bảng sản phẩm");
        }
    }
}
