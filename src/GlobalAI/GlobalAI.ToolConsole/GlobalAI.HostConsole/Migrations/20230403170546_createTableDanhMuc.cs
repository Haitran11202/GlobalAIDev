using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class createTableDanhMuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "P_DanhMuc",
               columns: table => new
               {
                   MaDanhMuc = table.Column<int>(type: "NUMBER(10)", nullable: false)
                       .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                   TenDanhMuc = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                  
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_P_DanhMuc", x => x.MaDanhMuc);
               },
               comment: "Demo bảng sản phẩm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
