using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GlobalAI.ProductDomain.Implements
{
    public class ChiTietDonHangServices : IChiTietDonHangServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ChiTietDonHangRepository _repositoryChiTietDonHang;

        public ChiTietDonHangServices( GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger)
        {
            _repositoryChiTietDonHang = new ChiTietDonHangRepository(dbContext, logger);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name = "input" ></ param >
        /// < returns ></ returns >
   
        public void CreateChiTietDonhang(AddChiTietDonHangDto input)
        {
            _repositoryChiTietDonHang.CreateChiTietDonHang(input);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //public SanPham GetById(int id)
        //{
        //    //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

        //    return _repositorySanPham.GetById(id);
        //}
        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public List<SanPham> GetByCategory(int id)
        //{
        //    //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(id)}");

        //    return _repositorySanPham.GetByCategory(id);
        //}



    }
}