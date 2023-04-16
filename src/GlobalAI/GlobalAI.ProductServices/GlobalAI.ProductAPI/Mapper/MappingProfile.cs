using AutoMapper;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.TraGia;
using System.Collections.Generic;

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
            //CreateMap<List<ChiTietDonHang>, List<AddChiTietDonHangDto>>().ReverseMap();
            CreateMap<ChiTietDonHang, AddChiTietDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, EditChiTietDonHangDto>().ReverseMap();
            CreateMap<GetChiTietDonHangDto, ChiTietDonHang>().ReverseMap();
            CreateMap<GetGioHangDto, GioHang>().ReverseMap();
            CreateMap<ChiTietDonHang, GetChiTietDonHangDto>().ReverseMap();
            CreateMap<GioHang, EditGioHangDto>().ReverseMap();
            CreateMap<GioHang, AddGioHangDto>().ReverseMap();
            CreateMap<GioHang, GetGioHangDto>().ReverseMap();
            CreateMap<TraGia, AddTraGiaDto>().ReverseMap();
            CreateMap<TraGia, UpdateTraGiaDto>().ReverseMap();
            CreateMap<TraGia, ApproveTraGiaDto>().ReverseMap();
            CreateMap<GetDonHangDto, DonHang>().ReverseMap();
            CreateMap<ChiTietTraGia, AddTraGiaDto>().ReverseMap();
            CreateMap<ChiTietTraGia, AddChiTietTraGiaDto>().ReverseMap();
            CreateMap<ChiTietTraGia, ChiTietTraGiaDto>().ReverseMap();
            CreateMap<TraGia, TraGiaDto>().ReverseMap();
        }
    }
}
