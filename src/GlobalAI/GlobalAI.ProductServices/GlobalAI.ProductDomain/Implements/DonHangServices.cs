using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace GlobalAI.ProductDomain.Implements
{
    public class DonHangServices : IDonHangServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DonHangRepository _repositoryDonHang;
        public DonHangServices( GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger)
        {
            _repositoryDonHang = new DonHangRepository(dbContext, logger);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetDonHangDto> FindAll(FindDonHangDto input)
        {
            return _repositoryDonHang.FindAll(input);
        }

        /// <summary>
        /// tạo đơn hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void CreateDonhang(AddDonHangDto input)
        {
            _repositoryDonHang.CreateDonHang(input);
            _dbContext.SaveChanges();
        }
    }
}