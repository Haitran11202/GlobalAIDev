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
        public SanPham Add(SanPham sanPham)
        {
            _dbSet.Add(sanPham); 
            _dbContext.SaveChanges();
            return sanPham;
        }
        public SanPham FindById(int id)
        {
            return _dbSet.SingleOrDefault(sp => sp.MaSanPham == id);
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