using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductRepositories;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class GioHangServices : IGioHangServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly GioHangRepository _repositoryGioHang;
        private readonly IMapper _mapper;
        public GioHangServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger, IMapper mapper) 
        {
            _repositoryGioHang = new GioHangRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;
            _mapper = mapper;
        }

        public GioHang CreateGiohang(AddGioHangDto input)
        {
            throw new NotImplementedException();
        }

        public GioHang DeleteGiohang(string id)
        {
            throw new NotImplementedException();
        }

        public GioHang EditGiohang(int maGSaler, string maSanPham, EditGioHangDto newGioHang)
        {
            var gioHang = _repositoryGioHang.FindGioHang(maGSaler, maSanPham);
            if(gioHang != null)
            {
                _repositoryGioHang.EditGioHang(gioHang, newGioHang);
                _dbContext.SaveChanges();
            }
            return gioHang;
        }
    }
}
