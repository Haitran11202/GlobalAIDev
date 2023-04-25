using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class DanhMucServices : IDanhMucServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<DanhMucServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DanhMucRepository _danhMucRepository;
        private readonly IMapper _mapper;
        public DanhMucServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<DanhMucServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _danhMucRepository = new DanhMucRepository(dbContext, logger, mapper);
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
        public DanhMuc Add(CreateDanhMucDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var inputInsert = _mapper.Map<DanhMuc>(input);
            inputInsert.CreatedBy = username;

            inputInsert = _danhMucRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }



        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _danhMucRepository.DeleteById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<DanhMucDto> FindAll(FilterDanhMucDto input)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<DanhMucDto>();
            var baiTinQuery = _danhMucRepository.FindAll(input, userId);

            result.Items = _mapper.Map<List<DanhMucDto>>(baiTinQuery.Items);
            result.TotalItems = baiTinQuery.TotalItems;

            return result;
        }

        public DanhMucDto GetById(int id)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _danhMucRepository.FindById(id);
            var result = _mapper.Map<DanhMucDto>(baiTin);
            return result;
        }
    }
}
