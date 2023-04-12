using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DonHang
{
    public class AddDonHangFullDto
    {
        public AddChiTietDonHangDto ChiTietDonHangFullDtos { get; set; }
        public AddDonHangDto donHang { get; set; }
    }
}
