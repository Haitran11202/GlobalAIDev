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
    [Table("P_GioHang")]
    public class GioHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }
        [ColumnSnackCase(nameof(MaGioHang))]
        public string MaGioHang { get; set; }
        [ColumnSnackCase(nameof(MaGSaler))]
        public int MaGSaler { get; set; }
        [ColumnSnackCase(nameof(MaSanPham))]
        public string MaSanPham { get; set; }
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }
        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }
    }
}
