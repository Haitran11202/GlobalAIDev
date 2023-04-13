using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.TraGia
{
    public class TraGiaDto
    {
        public int Id { get; set; }
        public int IdNguoiBan { get; set; }
        public int IdNguoiMua { get; set; }
        public int IdSanPham { get; set; }
        public decimal? GiaTien { get; set; }
        public string Usertype { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        #region Các thông tin khác
        /// <summary>
        /// Được duyệt bởi
        /// </summary>
        public string ApproveBy { get; set; }
        #endregion
    }
}
