using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.DemoEntities.Dto.Product
{
    public class AddSanPhamDto
    {
        public string TenSanPham { get; set; } = String.Empty;

        public string MoTa { get; set; } = String.Empty;


        public int GiaBan { get; set; }


        public int GiaChietKhau { get; set; }


        public int MaDanhMuc { get; set; }


        public int MaGStore { get; set; }


        public DateTime NgayDangKi { get; set; }


        public DateTime NgayDuyet { get; set; }
    }
}
