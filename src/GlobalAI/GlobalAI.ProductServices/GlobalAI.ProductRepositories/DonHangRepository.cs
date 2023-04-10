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
    public class DonHangRepository : BaseEFRepository<DonHang>
    {
        private readonly IMapper _mapper;
        public DonHangRepository(DbContext dbContext, ILogger logger,IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        //Summary
        // Lấy ra các hóa đơn có phân trang
        public PagingResult<GetDonHangDto> FindAll(FindDonHangDto input)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");
            PagingResult<GetDonHangDto> result = new();
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.MaDonHang).Where(p => !p.Deleted);
 
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetDonHangDto>();
            foreach (var item in sanphams)
            {
                var getSpDto = new GetDonHangDto
                {
                    MaDonHang = item.MaDonHang,
                    MaGSaler = item.MaGSaler,
                    MaGStore = item.MaGStore,
                    NgayHoanThanh = item.NgayHoanThanh,
                    SoTien = item.SoTien,
                    HinhThucThanhToan = item.HinhThucThanhToan,
                };
                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;
            
            return result;
        }
        //summary
        // thêm đơn hàng
        public void CreateDonHang(AddDonHangDto input)
        {
            var donHang = _mapper.Map<DonHang>(input);
            _dbSet.Add(donHang);
        }
        /// <summary>
        /// Tìm đơn hàng cần sửa, xóa
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        public DonHang FindById(int maDonHang)
        {
            var result = _dbSet.FirstOrDefault(donhang => donhang.MaDonHang == maDonHang);
            if (result != null && result.Deleted == true)
            {
                return null;
            }
            return result;
        }
        /// <summary>
        /// Sửa đơn hàng
        /// </summary>
        /// <param name="oldDonHang"></param>
        /// <param name="newDonHang"></param>
        /// <returns></returns>
        public DonHang EditDonHang(DonHang oldDonHang, AddDonHangDto newDonHang)
        {
            _mapper.Map(newDonHang, oldDonHang);
            _dbContext.SaveChanges();
            return oldDonHang;
        }
    }
}