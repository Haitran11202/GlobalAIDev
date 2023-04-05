using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;

using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.Product;


namespace GlobalAI.DemoRepositories
{
    public class SanPhamRepository : BaseEFRepository<SanPham>
    {
        public SanPhamRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<SanPham> FindAll(FindSanPhamDto input)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");
            PagingResult<SanPham> result = new();
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.MaSanPham).Where(p => !p.Deleted)
                .Where(r => (input.Keyword == null || r.TenSanPham.Contains(input.Keyword)));
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            result.Items = projectQuery.ToList();
            return result;
        }
        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SanPham GetById(int id)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(id)}");
            var sanpham = _dbSet.AsNoTracking().FirstOrDefault(sp => sp.MaSanPham == id);
            return sanpham;
        }
        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<SanPham> GetByCategory(int id)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(GetByCategory)}: input = {JsonSerializer.Serialize(id)}");
            var danhmucs = _dbSet.Where(sp => sp.MaDanhMuc == id).AsNoTracking().ToList();
            return danhmucs;
        }

    }
}