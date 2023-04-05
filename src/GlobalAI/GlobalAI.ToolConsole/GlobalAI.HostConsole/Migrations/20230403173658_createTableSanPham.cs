using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class createTableSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TenSanPham = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    GiaBan = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GiaChietKhau = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaDanhMuc = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaGStore = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NgayDangKi = table.Column<DateTime>(type: "DATE", nullable: true),
                    NgayDuyet = table.Column<DateTime>(type: "DATE", nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_SanPham", x => x.MaSanPham);
                },
                comment: "bảng sản phẩm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
