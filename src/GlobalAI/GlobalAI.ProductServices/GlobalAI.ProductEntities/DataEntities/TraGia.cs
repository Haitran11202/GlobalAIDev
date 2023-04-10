using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_TraGia")]
    public class TraGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(ID))]
        public int ID { get; set; }
        [ColumnSnackCase(nameof(MaTraGia))]
        public string MaTraGia { get; set; }
        [ColumnSnackCase(nameof(MaGSaler))]

        public int MaGSaler { get; set; }
        [ColumnSnackCase(nameof(MaSanPham))]

        public string MaSanPham { get; set; }
        [ColumnSnackCase(nameof(GiaTien))]

        public decimal GiaTien { get; set; }
        [ColumnSnackCase(nameof(Status))]

        public int Status { get; set; }
        [ColumnSnackCase(nameof(Deleted))]

        public bool Deleted { get; set; }


    }
}
