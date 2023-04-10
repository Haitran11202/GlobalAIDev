using AutoMapper;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;

namespace GlobalAI.ProductAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Đưa hết các cấu hình bạn muốn map giữa các object vào đây
            // Thuộc tính FullName trong UserViewModel được kết hợp từ FirstName và LastName trong User
            CreateMap<SanPham, AddSanPhamDto>().ReverseMap();
            CreateMap<DonHang, AddDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, AddChiTietDonHangDto>().ReverseMap();
            CreateMap<DonHang, AddDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, EditChiTietDonHangDto>().ReverseMap();

        }
    }
}
