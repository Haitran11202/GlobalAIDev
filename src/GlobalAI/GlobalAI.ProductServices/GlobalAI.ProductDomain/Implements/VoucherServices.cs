using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
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
using GlobalAI.ProductEntities.Dto.Voucher;

namespace GlobalAI.ProductDomain.Implements
{
    public class VoucherServices : IVoucherServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<VoucherServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly VoucherRepository _voucherRepository;
        private readonly IMapper _mapper;
        public VoucherServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<VoucherServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _voucherRepository = new VoucherRepository(dbContext, logger, mapper);
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
        public Voucher Add(CreateVoucherDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var inputInsert = _mapper.Map<Voucher>(input);

            inputInsert.CreatedBy = username; 
            inputInsert.Status = TrangThaiBaiTin.KICH_HOAT;

            inputInsert = _voucherRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }



        //public void Delete(int id)
        //{
        //    var username = CommonUtils.GetCurrentUsername(_httpContext);
        //    _voucherRepository.DeleteById(id, username);
        //    _dbContext.SaveChanges();
        //}

        ///// <summary>
        ///// Danh sach 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public PagingResult<VoucherDto> FindAll(FilterVoucherDto input)
        //{
        //    int? userId = CommonUtils.GetCurrentUserId(_httpContext);
        //    var usertype = CommonUtils.GetCurrentRole(_httpContext);

        //    var result = new PagingResult<VoucherDto>();
        //    var baiTinQuery = _voucherRepository.FindAll(input, userId);

        //    result.Items = _mapper.Map<List<VoucherDto>>(baiTinQuery.Items);
        //    result.TotalItems = baiTinQuery.TotalItems;

        //    return result;
        //}

        //public VoucherDto GetById(int id)
        //{
        //    int? userId = CommonUtils.GetCurrentUserId(_httpContext);
        //    var baiTin = _voucherRepository.FindById(id);
        //    var result = _mapper.Map<VoucherDto>(baiTin);
        //    return result;
        //}
    }
}
