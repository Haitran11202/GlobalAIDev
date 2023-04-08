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

namespace GlobalAI.DemoRepositories
{
    public class ChiTietDonHangRepository : BaseEFRepository<ChiTietDonHang>
    {
        
        public ChiTietDonHangRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }
        public void CreateChiTietDonHang(AddChiTietDonHangDto input)
        {
            var chitiet = new ChiTietDonHang
            {
                MaDonHang = input.MaDonHang,
                MaSanPham = input.MaSanPham,
                SoLuong = input.SoLuong,
            };
            _dbSet.Add(chitiet);

        }
        
    }
}