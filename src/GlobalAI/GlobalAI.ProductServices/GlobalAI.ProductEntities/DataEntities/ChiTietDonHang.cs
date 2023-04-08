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
    public class ChiTietDonHang
    {

        [Key]
        [ColumnSnackCase(nameof(MaDonHang))]
        public int MaDonHang { get; set; }
        
        [ColumnSnackCase(nameof(MaSanPham))]
        public int MaSanPham { get; set; }

        [ForeignKey("MaDonHang")]
        public DonHang DonHang { get; set; }

        [ForeignKey("MaSanPham")]
        public SanPham SanPham { get; set; }

    }
}
