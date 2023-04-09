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
using System.Net.Mail;

namespace GlobalAI.ProductRepositories
{
    public class ChiTietDonHangRepository : BaseEFRepository<ChiTietDonHang>
    {

        public ChiTietDonHangRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }
        public void CreateChiTietDonHang(AddChiTietDonHangDto input)
        {
            var madonhangcheck = _globalAIDbContext.DonHangs.Find(input.MaDonHang);
            var masanpham = _globalAIDbContext.SanPhams.Find(input.MaSanPham);
            if (madonhangcheck != null && masanpham != null)
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
}