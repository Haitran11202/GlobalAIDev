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


namespace GlobalAI.ProductRepositories

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
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.MaDonHang);


            if (input.PageSize != -1)
            {
                projectQuery = (IOrderedQueryable<DonHang>)projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetDonHangDto>();
            foreach (var item in sanphams)
            {
                var getSpDto = _mapper.Map<GetDonHangDto>(item);
                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;
            
            return result;
        }
        //summary
        // thêm đơn hàng
        public DonHang CreateDonHang(DonHang input)
        {
            _dbSet.Add(input);
            return input;
        }
        /// <summary>
        /// Tìm đơn hàng cần sửa, xóa
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        public DonHang FindById(string maDonHang)
        {
            var result = _dbSet.FirstOrDefault(donhang => donhang.MaDonHang == maDonHang);
            if (result != null && result.Deleted == false)
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


        public void DeleteDonHangById(int id)
        {
            var Result = _dbSet.FirstOrDefault((Order) => Order.Id == id);
            if (Result != null)
            {
                Result.Deleted = true;
                _dbContext.SaveChanges();
            }
        }

        public DonHang GetDonHang(int maDonHang)
        {
            return _dbSet.FirstOrDefault(dh => dh.Id == maDonHang);

        }
    }
}