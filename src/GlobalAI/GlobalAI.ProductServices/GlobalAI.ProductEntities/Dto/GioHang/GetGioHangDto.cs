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

namespace GlobalAI.ProductEntities.Dto.GioHang
{
    public class GetGioHangDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Id Người mua (Vì gstore và gsaler đều có thể mua hàng)
        /// (Lấy giá trị từ id trong bảng user)
        /// <
        public int IdNguoiMua { get; set; }

        /// <summary>
        /// Id Sản phẩm (Có thể trùng nhau)
        /// <
        public int? IdSanPham { get; set; }

        /// <summary>
        /// Số lượng sp
        /// <
        public int SoLuong { get; set; }

        /// <summary>
        /// Trạng thái
        /// <see cref="TrangThaiGioHang"/>
        /// <
        public int? Status { get; set; }
        
    }
}
