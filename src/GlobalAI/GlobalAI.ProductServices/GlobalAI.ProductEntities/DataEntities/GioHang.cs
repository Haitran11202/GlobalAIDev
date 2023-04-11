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
        [ColumnSnackCase(nameof(Id_gio_hang))]
        public string Id_gio_hang { get; set; }
        [ColumnSnackCase(nameof(Id_gsaler))]
        public int Id_gsaler { get; set; }
        [ColumnSnackCase(nameof(Id_san_pham))]
        public string Id_san_pham { get; set; }
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }
        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }
    }
}
