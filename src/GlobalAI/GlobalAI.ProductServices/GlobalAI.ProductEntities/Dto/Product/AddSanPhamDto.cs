using System.ComponentModel.DataAnnotations;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class AddSanPhamDto
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }  
        public string MoTa { get; set; } = String.Empty;
        public decimal GiaBan { get; set; }
        public decimal GiaChietKhau { get; set; }
        public string IdDanhMuc { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string Thumbnail { get; set; }

    }
}

