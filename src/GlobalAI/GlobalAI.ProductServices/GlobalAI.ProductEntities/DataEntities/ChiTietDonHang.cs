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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ColumnSnackCase(nameof(MaDonHang))]
        public string MaDonHang { get; set; }
       
        [ColumnSnackCase(nameof(MaSanPham))]
        public string MaSanPham { get; set; }

        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }
      
        [ColumnSnackCase(nameof(Deleted))]
        public int Deleted { get; set; }

    }
}
