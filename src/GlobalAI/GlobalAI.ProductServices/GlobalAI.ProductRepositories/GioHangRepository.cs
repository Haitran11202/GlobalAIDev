using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.Product;
using AutoMapper;
using Microsoft.AspNetCore.Http.Internal;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.DemoEntities.Dto.ChiTietDonHang;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mail;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.Utils;

namespace GlobalAI.ProductRepositories
{
    public class GioHangRepository : BaseEFRepository<GioHang>
    {
        private readonly IMapper _mapper;
        public GioHangRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }
        public List<GetGioHangDto> GetGioHang(int idNguoiMua)
        {
            var gioHangs = _dbSet.Where(g => g.IdNguoiMua == idNguoiMua && !g.Deleted).ToList();
            var results = _mapper.Map<List<GetGioHangDto>>(gioHangs);
            return results;
        }

        public GioHang AddGioHang(GioHang dto)
        {
            var item = _dbSet.FirstOrDefault(g => g.IdSanPham == dto.IdSanPham && !g.Deleted);
            if (item != null)
            {
                item.SoLuong += dto.SoLuong;
            }
            else
            {
                _dbSet.Add(dto);
            }
            return dto;
        }
        /// <summary>
        /// Tìm sản phẩm cần sửa, xóa
        /// </summary>
        public GioHang FindGioHang(int idGioHang)
        {
            var gioHang = _dbSet.FirstOrDefault(sp => sp.Id == idGioHang && !sp.Deleted);
            if (gioHang != null && gioHang.Deleted == true)
            {
                return null;
            }
            return gioHang;

        }
        public GioHang EditGioHang(GioHang oldGioHang, EditGioHangDto newGioHang)
        {
            _mapper.Map(newGioHang, oldGioHang);
            return oldGioHang;
        }

        public GioHang DeleteGioHang( int idGioHang)
        {
            var sanPhamXoa = FindGioHang(idGioHang);
            if (sanPhamXoa != null)
            {
                sanPhamXoa.Deleted = true;
                return sanPhamXoa;
            }
            return null;
        }

        public List<GetSanPhamDto> GetSanPhamByNguoiMua(int idNguoiMua)
        {
            var sanPhamIds = _dbSet.Where(gh => gh.IdNguoiMua == idNguoiMua && !gh.Deleted)
                .Select(c => c.IdSanPham);
            var sanPhams = _globalAIDbContext.SanPhams.Where(sp => sanPhamIds.Contains(sp.Id)).ToList();
            return _mapper.Map<List<GetSanPhamDto>>(sanPhams);
        }
        public GetGioHangDto GetGioHangByIdSanPham(int idSanPhamId)
        {
            var gioHang = _dbSet.FirstOrDefault(gh => gh.IdSanPham == idSanPhamId && !gh.Deleted);
            if (gioHang == null)
            {
                throw new Exception("Không tìm thấy giỏ hàng này");
            }
            return _mapper.Map<GetGioHangDto>(gioHang);

        }
    }
}