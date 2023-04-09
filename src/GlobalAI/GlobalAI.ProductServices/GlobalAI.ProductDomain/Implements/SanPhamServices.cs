
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;

﻿using AutoMapper;

using GlobalAI.DemoEntities.Dto.Product;

using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
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
        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="sanPham"></param>
        /// <returns>Sản phẩm vừa thêm vào</returns>
        public SanPham AddSanPham(AddSanPhamDto sanPham)
        {
            var newSanPham = new SanPham
            {
                TenSanPham = sanPham.TenSanPham,
                MaDanhMuc = sanPham.MaDanhMuc,
                MoTa = sanPham.MoTa,
                MaGStore = sanPham.MaGStore,
                GiaBan = sanPham.GiaBan,
                GiaChietKhau = sanPham.GiaChietKhau,
                NgayDangKi = sanPham.NgayDangKi,
                NgayDuyet = sanPham.NgayDuyet,
                Deleted = false
            };

            return _repositorySanPham.Add(newSanPham);
        }
        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về sản phẩm vừa xóa(Trường deleted = true)</returns>
        public SanPham DeleteSanPham(int id)
        {
            var findSanPham = _repositorySanPham.FindById(id);
            if (findSanPham != null)
            {
                _repositorySanPham.Delete(findSanPham);
            }
            return findSanPham;
        }
        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newSanPham"></param>
        /// <returns>Trả về sản phẩm đã được sửa</returns>
        public SanPham EditSanPham(int id, AddSanPhamDto newSanPham)
        {
            var findSanPham = _repositorySanPham.FindById(id);
            if (findSanPham != null)
            {
                _repositorySanPham.EditSanPham(newSanPham, findSanPham);
            }
            return findSanPham;


        }
        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input)
        {
            //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            return _repositorySanPham.FindAll(input);
        }

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SanPham GetById(int id)
        {
            //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            return _repositorySanPham.GetById(id);
        }
        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SanPham> GetByCategory(int id)
        {
            //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(id)}");

            return _repositorySanPham.GetByCategory(id);
        }



    }
}
