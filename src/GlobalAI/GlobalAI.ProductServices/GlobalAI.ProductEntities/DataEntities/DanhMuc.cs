using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_DanhMuc")]
    [Comment("Demo bảng danh mục sản phẩm")]
    public class DanhMuc
    {
        //public static string SEQ { get; } = $"SEQ_{nameof(DemoProduct).ToSnakeUpperCase()}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(MaDanhMuc))]
        public int MaDanhMuc { get; set; }

        

        [StringLength(400)]
        [ColumnSnackCase(nameof(TenDanhMuc))]
        public string TenDanhMuc { get; set; } = String.Empty;

    }
}
