using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GlobalAI.ProductRepositories
{
    public class ProductRepository : BaseEFRepository<Product>
    {
        private GlobalAIDbContext _dbContext {  get; set; } 
        public ProductRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        public List<SanPham> Add(SanPham product)
        {
            _dbContext.SanPhams.Add(product);
            return(_dbContext.SanPhams.ToList());
        }
        public List<SanPham> Put(SanPham product)
        {
            
            return (_dbContext.SanPhams.ToList());
        }
        public List<SanPham> Delete(SanPham product)
        {
            _dbContext.SanPhams.Add(product);
            return (_dbContext.SanPhams.ToList());
        }

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