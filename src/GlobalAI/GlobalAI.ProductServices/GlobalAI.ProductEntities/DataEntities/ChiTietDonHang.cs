using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string MaDonHang { get; set; }
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(MaSanPham))]
        public string MaSanPham { get; set; }
        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }
        /// <summary>
        /// Biến xóa
        /// </summary>
        [ColumnSnackCase(nameof(Deleted))]
        public int Deleted { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }

    }
}
