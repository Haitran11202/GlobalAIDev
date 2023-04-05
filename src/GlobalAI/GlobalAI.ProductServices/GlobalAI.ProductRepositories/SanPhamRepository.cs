using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GlobalAI.DemoRepositories
{
    public class SanPhamRepository : BaseEFRepository<SanPham>
    {
        public SanPhamRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        /// <summary>
        /// Tạo mới product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SanPham Add(AddSanPhamDto sanPham)
        {
            var newSanPham = new SanPham
            {
                TenSanPham = sanPham.TenSanPham,
                MaDanhMuc = sanPham.MaDanhMuc,
                MoTa = sanPham.MoTa,
                MaGStore = sanPham.MaGStore,
                GiaBan = sanPham.GiaBan,
                GiaChietKhau = sanPham.GiaChietKhau,
                NgayDangKi = sanPham.NgayDangKi,
                NgayDuyet = sanPham.NgayDuyet

            };
            _dbSet.Add(newSanPham); 
            _dbContext.SaveChanges();
            return newSanPham;
        }
        public SanPham FindById(int id)
        {
            return _dbSet.SingleOrDefault(sp => sp.MaSanPham == id);
        }
        public SanPham Put(AddSanPhamDto newSanPham, SanPham oldSanPham)
        {
            oldSanPham.TenSanPham = newSanPham.TenSanPham;
            oldSanPham.MaDanhMuc = newSanPham.MaDanhMuc;
            oldSanPham.MoTa = newSanPham.MoTa;
            oldSanPham.MaGStore = newSanPham.MaGStore;
            oldSanPham.GiaBan = newSanPham.GiaBan;
            oldSanPham.GiaChietKhau = newSanPham.GiaChietKhau;
            oldSanPham.NgayDangKi = newSanPham.NgayDangKi;
            oldSanPham.NgayDuyet = newSanPham.NgayDuyet;
            _dbContext.SaveChanges();
            return oldSanPham;
        }
        public void Delete(SanPham sanPham)
        {
            _dbSet.Remove(sanPham);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
       /* public PagingResult<Product> FindAll(FindProductDto input)
        {
            _logger.LogInformation($"{nameof(ProductRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            PagingResult<Product> result = new();

            var projectQuery = _dbSet.OrderByDescending(p => p.ProductRecordId)
                .Where(r => (input.Keyword == null || r.ProductName.Contains(input.Keyword)))
                        ;

            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }

            result.TotalItems = projectQuery.Count();
            result.Items = projectQuery.ToList();

            return result;
        }*/
    }
}