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
    public class AddDonHangDto
    {
        
        public DateTime NgayHoanThanh { get; set; }
        public int? MaGStore { get; set; }
        public int? MaGSaler { get; set; }
        public decimal? SoTien { get; set; }
        public string HinhThucThanhToan { get; set; }


    }
}