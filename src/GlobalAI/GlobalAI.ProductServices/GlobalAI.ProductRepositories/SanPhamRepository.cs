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


namespace GlobalAI.DemoRepositories
{
    public class SanPhamRepository : BaseEFRepository<SanPham>
    {
        private readonly IMapper _mapper;
        public SanPhamRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }
        /// <summary>
        /// Tạo mới product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SanPham Add(SanPham sanPham)
        {
            _dbSet.Add(sanPham);
            _dbContext.SaveChanges();
            return sanPham;
        }
        public SanPham EditSanPham(AddSanPhamDto newSanPham, SanPham oldSanPham)
        {
            oldSanPham.TenSanPham = newSanPham.TenSanPham;
            oldSanPham.MaDanhMuc = newSanPham.MaDanhMuc;
            oldSanPham.MoTa = newSanPham.MoTa;
            oldSanPham.MaGStore = newSanPham.MaGStore;
            oldSanPham.GiaBan = newSanPham.GiaBan;
            oldSanPham.GiaChietKhau = newSanPham.GiaChietKhau;
            oldSanPham.NgayDangKi = newSanPham.NgayDangKi;
            oldSanPham.NgayDuyet = newSanPham.NgayDuyet;
            _dbContext.SaveChanges();
            return oldSanPham;
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
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.MaSanPham).Where(p => !p.Deleted)
                .Where(r => (input.Keyword == null || r.TenSanPham.Contains(input.Keyword)));
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetSanPhamDto>();
            foreach ( var item in sanphams ) {
                var getSpDto = new GetSanPhamDto
                {
                    TenSanPham = item.TenSanPham,
                    MaDanhMuc = item.MaDanhMuc,
                    MaGStore = item.MaGStore,
                    GiaBan = item.GiaBan,
                    GiaChietKhau = item.GiaChietKhau,
                    NgayDangKi = item.NgayDangKi,
                    NgayDuyet = item.NgayDuyet,
                };
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
        public SanPham GetById(int id)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(id)}");
            var sanpham = _dbSet.AsNoTracking().Where(sp => !sp.Deleted).FirstOrDefault(sp => sp.MaSanPham == id);
            return sanpham;
        }
        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<SanPham> GetByCategory(int id)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(GetByCategory)}: input = {JsonSerializer.Serialize(id)}");
            var danhmucs = _dbSet.Where(sp => sp.MaDanhMuc == id).AsNoTracking().ToList();
            return danhmucs;
        }
        /// <summary>
        /// Tìm sản phầm cần sửa, xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SanPham FindById(int id)
        {
            var result = _dbSet.SingleOrDefault(sp => sp.MaSanPham == id);
            if(result != null && result.Deleted == true) 
            {
                return null;
            }
            return result;
        }

    }
}