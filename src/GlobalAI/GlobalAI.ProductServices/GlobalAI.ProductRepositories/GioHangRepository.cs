using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using GlobalAI.DemoEntities.Dto.Product;
using AutoMapper;
using Microsoft.AspNetCore.Http.Internal;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.DemoEntities.Dto.ChiTietDonHang;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mail;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.Utils;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using GlobalAI.ProductEntities.Dto.ThuocTinh;

namespace GlobalAI.ProductRepositories
{
    public class GioHangRepository : BaseEFRepository<GioHang>
    {
        private readonly IMapper _mapper;
        public GioHangRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Lấy ra giỏ theo id người mua 
        /// </summary>
        /// <param name="idNguoiMua"></param>
        /// <returns></returns>
        public List<GetGioHangDto> GetGioHang(int idNguoiMua)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)} -> {nameof(GetGioHang)} :idNguoiMua = {idNguoiMua}");

            var gioHangs = _dbSet.Where(g => g.IdNguoiMua == idNguoiMua && !g.Deleted).ToList();
            var results = _mapper.Map<List<GetGioHangDto>>(gioHangs);
            foreach (var gioHang in results)
            {
                gioHang.IdThuocTinhs = _globalAIDbContext.SanPhamChiTietThuocTinhs.Where(spcttt => spcttt.IdSanPhamChiTiet == gioHang.IdSanPhamChiTiet)
                                                            .Select(spcttt => spcttt.IdThuocTinhGiaTri).ToList();
            }
            return results;
        }
        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng, Nếu sản phẩm tổn tại trong giỏ hàng của người mua thì cộng thêm số lượng
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="idNguoiMua"></param>
        /// <returns></returns>
        public GioHang AddGioHang(AddGioHangChiTietDto dto, int idNguoiMua, string username)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)} -> {nameof(AddGioHang)} : GioHang = {JsonSerializer.Serialize(dto)}, idNguoiMua = {idNguoiMua}");
            var listIdSanPhamChiTiet = _globalAIDbContext.SanPhamChiTiets.Where(spct => spct.IdSanPham == dto.IdSanPham).Select(spct => spct.Id).ToList();
            var addGioHangDto = new AddGioHangDto() 
            {
                IdSanPham = dto.IdSanPham,
                SoLuong = dto.SoLuong,
                Status = dto.Status,
            };
            for (int i = 0; i < listIdSanPhamChiTiet.Count(); i ++)
            {
                var listThuocTinhGiaTri = _globalAIDbContext.SanPhamChiTietThuocTinhs.Where(spcttt => spcttt.IdSanPhamChiTiet == listIdSanPhamChiTiet[i]).Select(spcttt => spcttt.IdThuocTinhGiaTri).ToList();
                if(listThuocTinhGiaTri.SequenceEqual(dto.ThuocTinhs))
                {
                    addGioHangDto.IdSanPhamChiTiet = listIdSanPhamChiTiet[i];
                }    
            }    
            var item = _dbSet.FirstOrDefault(g => g.IdSanPhamChiTiet == addGioHangDto.IdSanPhamChiTiet && !g.Deleted && g.IdNguoiMua == idNguoiMua);
            if (item != null)
            {
                item.SoLuong += dto.SoLuong;
            }
            else
            {
                var gioHang = _mapper.Map<GioHang>(addGioHangDto);
                gioHang.IdNguoiMua = idNguoiMua;
                gioHang.CreatedBy = username;
                gioHang.CreatedDate = DateTime.Now;
                _dbSet.Add(gioHang);
            }
            return _mapper.Map<GioHang>(addGioHangDto);
        }
        /// <summary>
        /// Tìm sản phẩm cần sửa, xóa
        /// </summary>
        public GioHang FindGioHang(int idGioHang)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)}->{nameof(FindGioHang)}: idGioHang = {idGioHang}");

            var gioHang = _dbSet.FirstOrDefault(sp => sp.Id == idGioHang && !sp.Deleted);
            if (gioHang != null && gioHang.Deleted == true)
            {
                return null;
            }
            return gioHang;

        }
        /// <summary>
        /// Sửa giỏ hàng
        /// </summary>
        /// <param name="oldGioHang"></param>
        /// <param name="newGioHang"></param>
        /// <returns></returns>
        public GioHang EditGioHang(GioHang oldGioHang, EditGioHangDto newGioHang)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)}->{nameof(EditGioHang)}: oldGioHang = {JsonSerializer.Serialize(oldGioHang)}, newGiohang = {JsonSerializer.Serialize(newGioHang)}");
            _mapper.Map(newGioHang, oldGioHang);
            return oldGioHang;
        }
        /// <summary>
        /// Xóa giỏ hàng
        /// </summary>
        /// <param name="idGioHang"></param>
        /// <returns></returns>
        public GioHang DeleteGioHang( int idGioHang)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)}->{nameof(DeleteGioHang)}: idGioHang = {idGioHang}");
            var sanPhamXoa = FindGioHang(idGioHang);
            if (sanPhamXoa != null)
            {
                sanPhamXoa.Deleted = true;
                return sanPhamXoa;
            }
            return null;
        }
        /// <summary>
        /// Lấy sản phẩm chi tiết trong giỏ hàng theo id người mua
        /// </summary>
        /// <param name="idNguoiMua"></param>
        /// <returns></returns>
        public List<GetGioHangDto> GetSanPhamByNguoiMua(int idNguoiMua)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)} -> {nameof(GetSanPhamByNguoiMua)}: idNguoiMua = {idNguoiMua}");
            var gioHangs = _dbSet.Where(gh => gh.IdNguoiMua == idNguoiMua && !gh.Deleted).ToList();
            var result = _mapper.Map<List<GetGioHangDto>>(gioHangs);
            foreach(var gioHang in result)
            {
                gioHang.IdThuocTinhs = _globalAIDbContext.SanPhamChiTietThuocTinhs.Where(spcttt => spcttt.IdSanPhamChiTiet == gioHang.IdSanPhamChiTiet)
                                                            .Select(spcttt => spcttt.IdThuocTinhGiaTri).ToList();
            }    
            return result;
        }
        /// <summary>
        /// Lấy ra giỏ hàng theo id sản phẩm chi tiết 
        /// </summary>
        /// <param name="idSanPhamId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public GetGioHangDto GetGioHangByIdSanPhamChiTiet(int idSanPhamChiTiet)
        {
            _logger.LogInformation($"{nameof(GioHangRepository)} -> {nameof(GetGioHangByIdSanPhamChiTiet)} :idSanPhamChiTiet = {nameof(idSanPhamChiTiet)}");
            var gioHang = _dbSet.FirstOrDefault(gh => gh.IdSanPham == idSanPhamChiTiet && !gh.Deleted);
            return _mapper.Map<GetGioHangDto>(gioHang);
        }
    }
}