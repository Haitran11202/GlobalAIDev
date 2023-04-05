using GlobalAI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class FindSanPhamDto
    {
        public string TenSanPham { get; set;}
        public string MoTa { get; set; } = String.Empty;
        public decimal GiaBan { get; set; }
        public decimal GiaChietKhau { get; set; }
        public int MaDanhMuc { get; set; }
        public int MaGStore { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime NgayDuyet { get; set; }
    }
}
