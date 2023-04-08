using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    public class DonHang
    {
        [Key]
        [ColumnSnackCase(nameof(MaDonHang))]
        public int MaDonHang { get; set; }

        [ColumnSnackCase(nameof(NgayHoanThanh))]
        public DateTime NgayHoanThanh { get; set; }

        [ColumnSnackCase(nameof(MaGStore))]
        public int MaGStore { get; set; }

        [ColumnSnackCase(nameof(MaGSaler))]
        public int MaGSaler { get; set; }

        [ColumnSnackCase(nameof(SoTien))]
        public decimal SoTien { get; set; }


        [ColumnSnackCase(nameof(HinhThucThanhToan))]

        public string HinhThucThanhToan { get; set; }
    }
}
