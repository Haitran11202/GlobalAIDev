using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils;
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
        public GetFullGioHangDto GetGiohang()
        {
            var IdNguoiMua = CommonUtils.GetCurrentUserId(_httpContext);
            var UserName = CommonUtils.GetCurrentUsername(_httpContext);
            var gioHang = _repositoryGioHang.GetGioHang(IdNguoiMua);
            var getFullDonHangDto = new GetFullGioHangDto
            {
                GioHang = gioHang,
            };
            return getFullDonHangDto;
        }
        public GioHang CreateGiohang(AddGioHangDto input)
        {
            
            var gioHang = _mapper.Map<GioHang>(input);
            var idNguoiMua = CommonUtils.GetCurrentUserId(_httpContext);
            _repositoryGioHang.AddGioHang(gioHang, idNguoiMua);
            gioHang.IdNguoiMua = idNguoiMua;

            gioHang.CreatedBy = CommonUtils.GetCurrentUsername(_httpContext);
            gioHang.CreatedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return gioHang;
        }


        public GioHang DeleteGiohang(int idGioHang)
        {
            var result = _repositoryGioHang.DeleteGioHang(idGioHang);
            _dbContext.SaveChanges();
            return result;
        }

        public GioHang EditGiohang(int idGiohang, EditGioHangDto newGioHang)
        {
            var gioHang = _repositoryGioHang.FindGioHang(idGiohang);
            if(gioHang != null)
            {
                _repositoryGioHang.EditGioHang(gioHang, newGioHang);
                _dbContext.SaveChanges();
            }
            return gioHang;
        }

      
        /// <summary>
        /// Lấy ra danh sách sản phẩm trong giỏ hàng của người dùng
        /// </summary>
        /// <returns></returns>
        public List<GetSanPhamChiTietDto> getSanPhamTheoNguoiMua()
        {
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var sanPhams = _repositoryGioHang.GetSanPhamByNguoiMua(userId);
            return sanPhams;
        }
        public GetGioHangDto GetGioHangTheoIdSanPham(int idSanPham)
        {
            
            var sanPhams = _repositoryGioHang.GetGioHangByIdSanPhamChiTiet(idSanPham);
            if(sanPhams == null)
            {
                throw new Exception("Không tìm thấy giỏ hàng");
            }    
            return sanPhams;
        }
    }
}
