using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.Utils;
using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ChiTietDonHang
{
    public class AddChiTietDonHangDto
    {
        public string Id_don_hang { get; set; }
        public string Id_san_pham { get; set; }
        public int SoLuong { get; set; }
    }
}