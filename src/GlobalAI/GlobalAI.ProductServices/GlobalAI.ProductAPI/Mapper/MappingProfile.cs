using AutoMapper;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.GioHang;
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
            CreateMap<SanPham, GetSanPhamDto>().ReverseMap();
            CreateMap<GetSanPhamDto, SanPham>().ReverseMap();
            CreateMap<DonHang, AddDonHangDto>().ReverseMap();
            CreateMap<DonHang, AddDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, AddChiTietDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, EditChiTietDonHangDto>().ReverseMap();
            CreateMap<GioHang, EditGioHangDto>().ReverseMap();
            CreateMap<GioHang, AddGioHangDto>().ReverseMap();
            CreateMap<GioHang, GetGioHangDto>().ReverseMap();
            CreateMap<GetDonHangDto, DonHang>().ReverseMap();

        }
    }
}
