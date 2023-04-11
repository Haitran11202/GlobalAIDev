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
        [ColumnSnackCase(nameof(Id_don_hang))]
        public string Id_don_hang { get; set; }

        [ColumnSnackCase(nameof(Id_san_pham))]
        public string Id_san_pham { get; set; }

        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }
        /// <summary>
        /// Biến xóa
        /// </summary>
        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }

    }
}
