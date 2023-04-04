using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_SanPham")]
    [Comment("bảng sản phẩm")]
    public class SanPham
    {
        //public static string SEQ { get; } = $"SEQ_{nameof(DemoProduct).ToSnakeUpperCase()}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(MaSanPham))]
        public int MaSanPham { get; set; }

        [StringLength(400)]
        [ColumnSnackCase(nameof(TenSanPham))]
        public string TenSanPham { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(MoTa))]
        [StringLength(1000)]
        public string MoTa { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(GiaBan))]
        public int GiaBan { get; set; }

        [ColumnSnackCase(nameof(GiaChietKhau))]
        public int GiaChietKhau { get; set; }

        [ColumnSnackCase(nameof(MaDanhMuc))]
        public int MaDanhMuc { get; set; }

        [ColumnSnackCase(nameof(MaGStore))]
        public int MaGStore { get; set; }

        [ColumnSnackCase(nameof(NgayDangKi))]
        public DateTime NgayDangKi { get; set; }

        [ColumnSnackCase(nameof(NgayDuyet))]
        public DateTime NgayDuyet { get; set; }
    }
}
