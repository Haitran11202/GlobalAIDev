using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.ProductEntities.Dto.BaiTin;

namespace GlobalAI.ProductDomain.Implements
{

    public class BaiTinServices : IBaiTinServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<BaiTinServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly TinBaiRepository _baiTinRepository;
        private readonly IMapper _mapper;
        public BaiTinServices(GlobalAIDbContext dbContext, 
                IHttpContextAccessor httpContext, 
                DatabaseOptions databaseOptions, 
                ILogger<BaiTinServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _baiTinRepository = new TinBaiRepository(dbContext, logger, mapper);
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
        public BaiTin Add(CreateBaiTin input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
        
            var inputInsert = _mapper.Map<BaiTin>(input);

            inputInsert.CreatedBy = username;

            inputInsert.Status = TrangThaiBaiTin.KICH_HOAT;
            inputInsert = _baiTinRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }



        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _baiTinRepository.DeleteBaiTinById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<BaiTinDto> FindAll(FilterBaiTinDto input)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<BaiTinDto>();
            var baiTinQuery = _baiTinRepository.FindAll(input, userId);

            result.Items = _mapper.Map<List<BaiTinDto>>(baiTinQuery.Items);
            result.TotalItems = baiTinQuery.TotalItems;
     
            return result;
        }

        public BaiTinDto GetById(int id)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _baiTinRepository.FindById(id);
            var result = _mapper.Map<BaiTinDto>(baiTin);
            return result;
        }

        public BaiTinDto GetBySlug(string slug)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _baiTinRepository.FindBySlug(slug);
            var result = _mapper.Map<BaiTinDto>(baiTin);
            return result;
        }
    }
}
