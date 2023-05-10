using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    public class GetSanPhamChiTietDto
    {
        private string _moTa;

        [Required(ErrorMessage = "Sản phẩm không được bỏ trống")]
        public int IdSanPham { get; set; }

        [Required(ErrorMessage = "Thuộc tính giá trị không được bỏ trống")]
        public Dictionary<String, List<AddThuocTinhGiaTriDto>> ThuocTinhs { get; set; }

        //[Required(ErrorMessage = "Danh mục thuộc tính không được bỏ trống")]
        public int? IdDanhMucThuocTinh { get; set; }

       
        public int SoLuong { get; set; }
        public string MoTa { get => _moTa; set => _moTa = value?.Trim(); }
        public decimal? GiaBan { get; set; }
        public decimal? GiaChietKhau { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public string Thumbnail { get; set; }
    }
}
