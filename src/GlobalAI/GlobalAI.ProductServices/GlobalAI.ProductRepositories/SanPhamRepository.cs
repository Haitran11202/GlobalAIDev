using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
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
        /// <param name="sanPham"></param>
        /// <returns> trả về SanPham được thêm vào  </returns>
        public SanPham Add(SanPham sanPham)
        {
            return _dbSet.Add(sanPham).Entity;
        }

        /// <summary>
        /// Tìm sản phầm
        /// </summary>
        /// <param name="id"></param>
        /// <returns> trả về SanPham tìm được theo id</returns>
        public SanPham FindById(int id)
        {
            return _dbSet.SingleOrDefault(sp => sp.MaSanPham == id);
        }

        /// <summary>
        /// Xóa sản phầm
        /// </summary>
        /// <param name="sanPham"></param>
        /// <returns></returns>
        /*public void Delete(SanPham sanPham)
        {
            _dbSet.Remove(sanPham);
            _dbContext.SaveChanges();
        }*/
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