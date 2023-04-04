using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto;
using GlobalAI.DemoEntities.Dto.Product;
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
        public SanPham Add(SanPham input)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}-> {nameof(Add)}: input = {JsonSerializer.Serialize(input)}");
            
            return _dbSet.Add(input).Entity;
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

            var projectQuery = _dbSet.OrderByDescending(p => p.MaSanPham)
                .Where(r => (input.Keyword == null || r.TenSanPham.Contains(input.Keyword)))
                        ;

            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }

            result.TotalItems = projectQuery.Count();
            result.Items = projectQuery.ToList();

            return result;
        }
    }
}