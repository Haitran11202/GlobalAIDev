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
    [Table("P_DonHang")]
    [Comment("bảng đơn hàng")]
    public class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ColumnSnackCase(nameof(MaDonHang))]
        public string MaDonHang { get; set; }

        [ColumnSnackCase(nameof(NgayHoanThanh))]
        public DateTime NgayHoanThanh { get; set; }

        [ColumnSnackCase(nameof(MaGStore))]
        public int? MaGStore { get; set; }

        [ColumnSnackCase(nameof(MaGSaler))]
        public int? MaGSaler { get; set; }

        [ColumnSnackCase(nameof(SoTien))]
        public decimal? SoTien { get; set; }


        [ColumnSnackCase(nameof(HinhThucThanhToan))]

        public string HinhThucThanhToan { get; set; }
        [ColumnSnackCase(nameof(Deleted))]

        public bool Deleted { get; set; }
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }
    }
}
