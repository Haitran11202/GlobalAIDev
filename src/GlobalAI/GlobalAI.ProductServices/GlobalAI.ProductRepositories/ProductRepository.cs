using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.DataEntities;
using GlobalAI.DemoEntities.Dto.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GlobalAI.DemoRepositories
{
    public class ProductRepository : BaseEFRepository<Product>
    {
        public ProductRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        /// <summary>
        /// Tạo mới product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Product Add(Product input)
        {
            _logger.LogInformation($"{nameof(ProductRepository)}-> {nameof(Add)}: input = {JsonSerializer.Serialize(input)}");
            
            return _dbSet.Add(input).Entity;
        }

        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<Product> FindAll(FindProductDto input)
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
        }
    }
}