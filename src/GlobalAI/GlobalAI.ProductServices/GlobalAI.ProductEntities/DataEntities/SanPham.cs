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
    [Table("P_SanPham")]
    [Comment("bảng sản phẩm")]
    public class SanPham
    {
        //public static string SEQ { get; } = $"SEQ_{nameof(DemoProduct).ToSnakeUpperCase()}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ColumnSnackCase(nameof(MaSanPham))]
        public string MaSanPham { get; set; }

        [StringLength(400)]
        [ColumnSnackCase(nameof(TenSanPham))]
        public string TenSanPham { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(MoTa))]
        [StringLength(1000)]
        public string MoTa { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(GiaBan))]
        public decimal GiaBan { get; set; }

        [ColumnSnackCase(nameof(GiaChietKhau))]
        public decimal GiaChietKhau { get; set; }

        [ColumnSnackCase(nameof(MaDanhMuc))]
        public string MaDanhMuc { get; set; }

        [ColumnSnackCase(nameof(MaGStore))]
        public int MaGStore { get; set; }

        [ColumnSnackCase(nameof(NgayDangKi))]
        public DateTime NgayDangKi { get; set; }

        [ColumnSnackCase(nameof(NgayDuyet))]
        public DateTime NgayDuyet { get; set; }
        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }

        #region audit
        [MaxLength(50)]
        [ColumnSnackCase(nameof(CreatedBy), TypeName = "VARCHAR2")]
        public string? CreatedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(CreatedDate), TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(DeletedBy), TypeName = "VARCHAR2")]
        public string? DeletedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(DeletedDate), TypeName = "DATE")]
        public DateTime? DeletedDate { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(ModifiedBy), TypeName = "VARCHAR2")]
        public string? ModifiedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(ModifiedDate), TypeName = "DATE")]
        public DateTime? ModifiedDate { get; set; }
        #endregion

    }
}
