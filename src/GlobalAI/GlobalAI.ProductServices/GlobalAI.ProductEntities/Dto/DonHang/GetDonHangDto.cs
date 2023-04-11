using GlobalAI.Utils;
using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class GetDonHangDto
    {
       
        public string Id_don_hang { get; set; }
        public DateTime NgayHoanThanh { get; set; }
        public int? Id_gstore { get; set; }
        public int? Id_gsaler { get; set; }
        public decimal? SoTien { get; set; }
        public string HinhThucThanhToan { get; set; }

    }
}
