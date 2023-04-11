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
        private string _tenSP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        [StringLength(400)]
        public string TenSanPham { get => _tenSP; set => _tenSP = value?.Trim(); }
        public string IdSanPham { get; set; }
        [StringLength(1000)]
        public string MoTa { get; set; } = String.Empty;
        public decimal GiaBan { get; set; }
        public decimal GiaChietKhau { get; set; }
        public string IdDanhMuc { get; set; }
        public int IdGStore { get; set; }
    }
}

