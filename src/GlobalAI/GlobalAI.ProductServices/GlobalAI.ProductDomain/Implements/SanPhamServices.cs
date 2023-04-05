using GlobalAI.DataAccess.Base;
using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly SanPhamRepository _repositorySanPham;
        public SanPhamServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger) 
        {
            _repositorySanPham = new SanPhamRepository(dbContext, logger);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext; 
            _httpContext = httpContext;

        }
        /// <summary>
        /// Services thêm sản phẩm
        /// </summary>
        /// <param name="sanPham"></param>
        /// <returns></returns>
        public SanPham AddSanPham(AddSanPhamDto sanPham)
        {
            _logger.LogInformation($"{nameof(AddSanPham)}: input = {JsonSerializer.Serialize(sanPham)}");

            // Convert từ AddSanPhamDto to SanPham
            var newSanPham = new SanPham
            {
                TenSanPham = sanPham.TenSanPham,
                MoTa = sanPham.MoTa,
                GiaBan = sanPham.GiaBan,
                GiaChietKhau = sanPham.GiaChietKhau,
                MaDanhMuc = sanPham.MaDanhMuc,
                MaGStore = sanPham.MaGStore,
                NgayDangKi = sanPham.NgayDangKi,
                NgayDuyet = sanPham.NgayDuyet
            };
            _repositorySanPham.Add(newSanPham);
            _dbContext.SaveChanges();
            return newSanPham;
        }
        
        public AddSanPhamDto DeleteSanPham(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newSanPham"></param>
        /// <returns></returns>
        public SanPham PutSanPham(int id, AddSanPhamDto newSanPham)
        {
            _logger.LogInformation($"{nameof(PutSanPham)}: input = {JsonSerializer.Serialize(newSanPham)}");

            // Tìm sản phẩm theo id
            var findSanPham = _repositorySanPham.FindById(id);
            if (findSanPham == null)
            {
                return findSanPham;
            }
            else
            {
                // Gán các property của findSanPham bằng property của newSanPham
                findSanPham.TenSanPham = newSanPham.TenSanPham;
                findSanPham.MaDanhMuc = newSanPham.MaDanhMuc;
                findSanPham.MoTa = newSanPham.MoTa;
                findSanPham.MaGStore = newSanPham.MaGStore;
                findSanPham.GiaBan = newSanPham.GiaBan;
                findSanPham.GiaChietKhau = newSanPham.GiaChietKhau;
                findSanPham.NgayDangKi = newSanPham.NgayDangKi;
                findSanPham.NgayDuyet = newSanPham.NgayDuyet;
            }
            _dbContext.SaveChanges();
            return findSanPham;
        }
    }
}
