using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.Product;
using AutoMapper;
using Microsoft.AspNetCore.Http.Internal;
using System.Net.WebSockets;
using GlobalAI.Utils.ConstantVariables.Product;

namespace GlobalAI.ProductRepositories
{
    public class SanPhamRepository : BaseEFRepository<SanPham>
    {
        private readonly IMapper _mapper;
        public SanPhamRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }
        public List<GetSanPhamDto> GetFullSanPham() {
            var result = _dbSet.ToList();
            return _mapper.Map<List<GetSanPhamDto>>(result);
        }
        /// <summary>
        /// Tạo mới product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void Add(SanPham sanPham)
        {
            _dbSet.Add(sanPham);
        }
        public void EditSanPham(AddSanPhamDto newSanPham, SanPham oldSanPham)
        {
            _mapper.Map(newSanPham, oldSanPham);
        }
        public void Delete(SanPham sanPham)
        {
            sanPham.Deleted = true;
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");
            PagingResult<GetSanPhamDto> result = new();
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.Id).Where(p => !p.Deleted)
                .Where(r => (input.Keyword == null || r.TenSanPham.Contains(input.Keyword)));
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetSanPhamDto>();
            foreach ( var item in sanphams ) {
                var getSpDto = _mapper.Map<GetSanPhamDto>(item);
               
                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;
            return result;
        }
        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SanPham GetById(int idSanPham)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(idSanPham)}");
            var sanpham = _dbSet.AsNoTracking().Where(sp => !sp.Deleted).FirstOrDefault(sp => sp.Id == idSanPham);

            return sanpham;
        }
        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> GetByCategory(string idDanhMuc, FindSanPhamByCatetoryDto input)
        {

            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(GetByCategory)}: input = {JsonSerializer.Serialize(idDanhMuc)}");
            PagingResult<GetSanPhamDto> result = new();
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.Id).Where(p => !p.Deleted && p.IdDanhMuc == idDanhMuc)
                .Where(r => (input.Keyword == null || r.TenSanPham.Contains(input.Keyword)));
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetSanPhamDto>();
            foreach (var item in sanphams)
            {
                var getSpDto = _mapper.Map<GetSanPhamDto>(item);
                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;
            return result;
        }
        /// <summary>
        /// Tìm sản phầm cần sửa, xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SanPham FindByIdSanPham(string idSanPham)
        {

            var result = _dbSet.SingleOrDefault(sp => sp.MaSanPham == idSanPham);

            if(result != null && result.Deleted == true) 
            {
                return null;
            }
            return result;
        }
        /// <summary>
        /// Tìm sản phầm cần sửa theo id lưu trong Database
        /// </summary>
        /// <param name="idSanPham"></param>
        /// <returns></returns>
        public SanPham FindById(int idDonHang)
        {
            var result = _dbSet.SingleOrDefault(sp => sp.Id == idDonHang);
            if (result != null && result.Deleted == true)
            {
                return null;
            }
            return result;
        }
        public List<SanPham> GetSanPhamFull()
        {
            var result = _dbSet.ToList();
            
            return result;
        }

    }
}