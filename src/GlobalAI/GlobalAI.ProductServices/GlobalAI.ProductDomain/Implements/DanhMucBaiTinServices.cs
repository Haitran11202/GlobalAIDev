using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.ProductRepositories;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;

namespace GlobalAI.ProductDomain.Implements
{
    public class DanhMucBaiTinServices : IDanhMucBaiTinServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<DanhMucBaiTinServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DanhMucBaiTinRepository _danhMucBaiTinRepository;
        private readonly IMapper _mapper;
        public DanhMucBaiTinServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<DanhMucBaiTinServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _danhMucBaiTinRepository = new DanhMucBaiTinRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        /// <summary>
        /// thêm bản ghi 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public DanhMucBaiTin Add(CreateDanhMucBaiTin input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var inputInsert = _mapper.Map<DanhMucBaiTin>(input);

            inputInsert.CreatedBy = username;

            inputInsert.Status = TrangThaiBaiTin.KICH_HOAT;
            inputInsert = _danhMucBaiTinRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }



        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _danhMucBaiTinRepository.DeleteById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<DanhMucBaiTinDto> FindAll(FilterDanhMucBaiTinDto input)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<DanhMucBaiTinDto>();
            var baiTinQuery = _danhMucBaiTinRepository.FindAll(input, userId);

            result.Items = _mapper.Map<List<DanhMucBaiTinDto>>(baiTinQuery.Items);
            result.TotalItems = baiTinQuery.TotalItems;

            return result;
        }

        public DanhMucBaiTinDto GetById(int id)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _danhMucBaiTinRepository.FindById(id);
            var result = _mapper.Map<DanhMucBaiTinDto>(baiTin);
            return result;
        }
    }
}
