namespace GlobalAI.ProductEntities.Dto.Product
{
    public class AddSanPhamDto
    {
        public string Id_san_pham { get; set; }
        public string TenSanPham { get; set; } = String.Empty;
        public string MoTa { get; set; } = String.Empty;
        public decimal GiaBan { get; set; }
        public decimal GiaChietKhau { get; set; }
        public string Id_danh_muc { get; set; }
        public int Id_gstore { get; set; }

        public DateTime NgayDangKi { get; set; }
        public DateTime NgayDuyet { get; set; }
        public int Status { get; set; }

    }
}

