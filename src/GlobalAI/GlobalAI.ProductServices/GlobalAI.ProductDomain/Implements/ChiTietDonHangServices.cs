using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class ChiTietDonHangServices : IChiTietDonHangServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ChiTietDonHangRepository _repositoryChiTietDonHang;
        private readonly IMapper _mapper;
        public ChiTietDonHangServices( GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryChiTietDonHang = new ChiTietDonHangRepository(dbContext, logger, mapper);
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
        /// Edit chi tiết đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <param name="maSanPham"></param>
        /// <param name="newDonHang"></param>
        /// <returns></returns>
        public ChiTietDonHang EditChiTietDonhang(string maDonHang, string maSanPham, EditChiTietDonHangDto newDonHang)
        {
            var result = _repositoryChiTietDonHang.FindChiTietDonHang(maDonHang, maSanPham);
            if (result != null)
            {
                _repositoryChiTietDonHang.EditChiTietDonHang(result, newDonHang);
                _dbContext.SaveChanges();
            }
            return result;
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