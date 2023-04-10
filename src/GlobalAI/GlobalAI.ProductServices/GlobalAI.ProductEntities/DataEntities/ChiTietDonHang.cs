using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_ChiTietDonHang")]
    [Comment("bảng chi tiết đơn hàng")]
    public class ChiTietDonHang
    {
        /// <summary>
        /// Mã chi tiết đơn hàng
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(ID))]
        public int ID {get; set;}
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        [ColumnSnackCase(nameof(MaDonHang))]
        public int MaDonHang { get; set; }
        [Key]
        [ColumnSnackCase(nameof(MaSanPham))]
        public int MaSanPham { get; set; }

        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }
        /// <summary>
        /// Biến xóa
        /// </summary>
        [ColumnSnackCase(nameof(Deleted))]
        public int Deleted { get; set; }

    }
}
