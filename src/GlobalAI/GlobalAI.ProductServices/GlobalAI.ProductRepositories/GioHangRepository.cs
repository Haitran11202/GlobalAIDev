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

namespace GlobalAI.ProductRepositories
{
    public class GioHangRepository : BaseEFRepository<GioHang>
    {
        private readonly IMapper _mapper;
        public GioHangRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public GioHang AddGioHang(GioHang dto)
        {
            _dbSet.Add(dto);
            return dto;
        }
        /// <summary>
        /// Tìm sản phẩm cần sửa, xóa
        /// </summary>
        public GioHang FindGioHang(int maGSaler, string maSanPham)
        {
            var gioHang = _dbSet.FirstOrDefault(sp => sp.IdNguoiMua == maGSaler && sp.IdSanPham == maSanPham);
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

        public GioHang DeleteGioHang(int maGSaler, string maSanPham)
        {
            var sanPhamEdit = FindGioHang(maGSaler, maSanPham);
            if (sanPhamEdit != null)
            {
                sanPhamEdit.Deleted = true;
                return sanPhamEdit;
            }
            return null;

        }
    }
}