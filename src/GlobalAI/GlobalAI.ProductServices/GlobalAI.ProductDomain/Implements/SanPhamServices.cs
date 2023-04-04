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
        public SanPham AddSanPham(AddSanPhamDto sanPham)
        {
            return _repositorySanPham.Add(sanPham);
        }

        public AddSanPhamDto DeleteSanPham(int id)
        {
            throw new NotImplementedException();
        }

        public SanPham PutSanPham(int id, AddSanPhamDto newSanPham)
        {
            var findSanPham = _repositorySanPham.FindById(id);
            return _repositorySanPham.Put(newSanPham, findSanPham);
            

        }
    }
}
