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

namespace GlobalAI.ProductRepositories
{
    public class ChiTietDonHangRepository : BaseEFRepository<ChiTietDonHang>
    {
        private readonly IMapper _mapper;
        public ChiTietDonHangRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }
        public ChiTietDonHang CreateChiTietDonHang(ChiTietDonHang input)
        {
            var madonhangcheck = _globalAIDbContext.DonHangs.Find(input.MaDonHang);
            var masanpham = _globalAIDbContext.SanPhams.Find(input.MaSanPham);
            if (madonhangcheck != null && masanpham != null)
            {
                MaDonHang = input.MaDonHang,
                MaSanPham = input.MaSanPham,
                SoLuong = input.SoLuong,
            };
            _dbSet.Add(chitiet);
        }
        /// <summary>
        /// Tìm sản phẩm cần sửa, xóa
        /// </summary>
        public ChiTietDonHang FindChiTietDonHang(string maDonHang, string maSanPham)
        {
            var donHang = _dbSet.FirstOrDefault(sp => sp.MaDonHang == maDonHang && sp.MaSanPham == maSanPham);
            if (donHang != null && donHang.Deleted == true)
            {
                return null;
            }
            return donHang;

        }
        public ChiTietDonHang EditChiTietDonHang(ChiTietDonHang oldDonHang, EditChiTietDonHangDto newDonHang)
        {
            _mapper.Map(newDonHang, oldDonHang);
            return oldDonHang;
        }

    }
}