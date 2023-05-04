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
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.Utils.ConstantVariables.Product;
using System.ServiceModel;
using GlobalAI.Utils;

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

        /// <summary>
        /// Xóa đơn hàng theo id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDonHangById(int id)
        {
            var Result = _dbSet.FirstOrDefault((Order) => Order.Id == id);
            if (Result != null)
            {
                Result.Deleted = true;
                _dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Lấy đơn hàng theo id
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        public DonHang GetDonHang(int maDonHang)
        {
            return _dbSet.FirstOrDefault(dh => dh.Id == maDonHang);

        }
        /// <summary>
        /// Cập nhật trạng thái đơn hàng
        /// </summary>
        /// <param name="updateDh"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public DonHang UpdateStatusDonHang(UpdateStatusDonHangDto updateStatusDh)
        {
            var result = _dbSet.FirstOrDefault(dh => dh.Id == updateStatusDh.ID);
            if (result == null)
            {
                throw new InvalidDataException("Don hang khong ton tai!");
            }
            switch (updateStatusDh.Status)
            {
                case 1:
                    result.Status = TrangThaiDonHang.TAO_MOI;
                    break;
                case 2:
                    result.Status = TrangThaiDonHang.DA_XAC_NHAN;
                    break;
                case 3:
                    result.Status = TrangThaiDonHang.HOAN_THANH;
                    break;
                default:
                    throw new InvalidDataException("Trang thai khong hop le!");
            }
            return result;
        }
        public List<GetDonHangDto> GetDonHangByIdGstore (int idGstore)
        {
            var result =  _dbSet.Where(dh =>  dh.IdGStore == idGstore).AsNoTracking().ToList();
            return _mapper.Map<List<GetDonHangDto>>(result);
        }
    }
}