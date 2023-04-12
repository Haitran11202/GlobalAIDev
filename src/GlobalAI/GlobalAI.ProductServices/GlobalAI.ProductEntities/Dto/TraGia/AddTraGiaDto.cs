using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.TraGia
{
    public class AddTraGiaDto
    {
        public string MaTraGia { get; set; }
        public string MaSanPham { get; set; }
        public decimal GiaTien { get; set; }
    }
}
