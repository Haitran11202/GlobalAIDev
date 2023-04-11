using GlobalAI.Utils;
using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class AddSanPhamDto
    {
        public string MaSanPham { get; set; }
        private string _tenSP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        public string TenSanPham { get => _tenSP; set => _tenSP = value?.Trim(); }
        public string MoTa { get; set; } = String.Empty;
        public decimal GiaBan { get; set; }
        public decimal GiaChietKhau { get; set; }
        public string MaDanhMuc { get; set; }
        public int MaGStore { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime NgayDuyet { get; set; }

    }
}

