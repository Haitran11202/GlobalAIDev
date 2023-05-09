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
using GlobalAI.ProductEntities.Dto.Voucher;
using System.Xml.Linq;

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
            if(input.ParentId == 0 )
            {
                input.ParentId = null;
            }
            var inputInsert = _mapper.Map<DanhMucBaiTin>(input);

            inputInsert.CreatedBy = username;

            inputInsert.Status = TrangThaiDanhMucBaiTin.KHOI_TAO;

            inputInsert = _danhMucBaiTinRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }


        /// <summary>
        /// xoa danh muc bai tin
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _danhMucBaiTinRepository.DeleteById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach dang to list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<DanhMucBaiTinDto> FindAll(FilterDanhMucBaiTinDto input)
        {
            //int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            //var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<DanhMucBaiTinDto>();
            var baiTinQuery = _danhMucBaiTinRepository.FindAll(input);

            result.Items = _mapper.Map<List<DanhMucBaiTinDto>>(baiTinQuery.Items);
            result.TotalItems = baiTinQuery.TotalItems;

            return result;
        }


        public PagingResult<TreesDanhMucBaiTinDto> FindAllTrees(FilterDanhMucBaiTinDto input)
        {
            var result = new PagingResult<TreesDanhMucBaiTinDto>();

            // Lấy danh sách cây danh mục bài tin
            var danhMucBaiTinQuery = _danhMucBaiTinRepository.FindAll(input);
            var danhMucBaiTinDtos = _mapper.Map<List<DanhMucBaiTinDto>>(danhMucBaiTinQuery.Items);

            // Xây dựng cây danh mục bài tin
            var trees = BuildDanhMucBaiTinTrees(danhMucBaiTinDtos);

            // Phân trang
            result.TotalItems = trees.Count;
            //if (input.PageSize != -1)
            //{
            //    trees = trees.Skip(input.Skip).Take(input.PageSize);
            //}
            result.Items = trees;
            //result.Items = trees.Skip(input.Skip).Take(input.Take).ToList();

            return result;
        }

        private List<TreesDanhMucBaiTinDto> BuildDanhMucBaiTinTrees(List<DanhMucBaiTinDto> danhMucBaiTinDtos)
        {
            var treeMap = new Dictionary<int, TreesDanhMucBaiTinDto>();
            var roots = new List<TreesDanhMucBaiTinDto>();

            foreach (var dto in danhMucBaiTinDtos)
            {
                var node = new TreesDanhMucBaiTinDto
                {
                    Id = dto.Id,
                    TenDanhMuc = dto.TenDanhMuc,
                    MaDanhMuc = dto.MaDanhMuc,
                    CreatedDate = dto.CreatedDate,
                    CreatedBy = dto.CreatedBy,
                    ParentId = dto.ParentId,
                    IsDisplayOnHomePage = dto.IsDisplayOnHomePage,
                    Status = dto.Status,
                    Children = new List<TreesDanhMucBaiTinDto>()
                };

                treeMap[dto.Id] = node;

                if (dto.ParentId == null)
                {
                    roots.Add(node);
                }
                else
                {
                    var parent = treeMap.GetValueOrDefault(dto.ParentId.Value);
                    parent?.Children.Add(node);
                }
            }

            return roots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DanhMucBaiTinDto GetById(int id)
        {
            //int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _danhMucBaiTinRepository.FindById(id);
            var result = _mapper.Map<DanhMucBaiTinDto>(baiTin);
            return result;
        }

        public void Update(UpdateDanhMucBaiTinDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var inputUpdate = _mapper.Map<DanhMucBaiTin>(input);
            inputUpdate.ModifiedBy = username;
            _danhMucBaiTinRepository.Update(inputUpdate);
            _dbContext.SaveChanges();
        }
    }
}
