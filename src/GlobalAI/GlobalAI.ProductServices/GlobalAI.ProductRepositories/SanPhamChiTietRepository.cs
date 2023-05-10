using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils;
using GlobalAI.Utils.ConstantVariables.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class SanPhamChiTietRepository : BaseEFRepository<SanPhamChiTiet>
    {
        private readonly IMapper _mapper;
        public SanPhamChiTietRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public PagingResult<SanPhamChiTiet> FindAll(FilterSanPhamChiTietDto input)
        {
            PagingResult<SanPhamChiTiet> result = new();

            var sanPhamChiTietQuery = (from sanPhamChiTiet in _dbSet
                               where sanPhamChiTiet.Deleted == DeletedBool.NO
                               //&& (input.IdSanPham == null || input.IdSanPham == sanPhamChiTiet.IdSanPham)
                               && (input.Status == null || input.Status == sanPhamChiTiet.Status)
                               select sanPhamChiTiet);

            result.TotalItems = sanPhamChiTietQuery.Count();
            if (!string.IsNullOrEmpty(input.SortBy) && !string.IsNullOrEmpty(input.SortOrder))
            {
                switch (input.SortBy)
                {
                    case "SoLuong":
                        if (input.SortOrder.ToLower() == "asc")
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderBy(x => x.SoLuong);
                        }
                        else
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.SoLuong);
                        }
                        break;

                    case "CreatedDate":
                        if (input.SortOrder.ToLower() == "asc")
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderBy(x => x.CreatedDate);
                        }
                        else
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.CreatedDate);
                        }
                        break;

                    case "LuotBan":
                        if (input.SortOrder.ToLower() == "asc")
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderBy(x => x.LuotBan);
                        }
                        else
                        {
                            sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.LuotBan);
                        }
                        break;
                    // Các trường hợp sắp xếp theo các trường khác có thể được thêm vào ở đây
                    default:
                        sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.Id);
                        break;
                }
            }
            else
            {
                sanPhamChiTietQuery = sanPhamChiTietQuery.OrderByDescending(x => x.Id);
            }

            if (input.PageSize != -1)
            {
                sanPhamChiTietQuery = sanPhamChiTietQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.Items = sanPhamChiTietQuery;
            return result;
        }

        /// <summary>
        /// Thêm sản phẩm chi tiết
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public SanPhamChiTiet Add(SanPhamChiTiet entity, string username)
        {
            _logger.LogInformation($"{nameof(Add)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);

            return entity;
        }

        /// <summary>
        /// Add thuộc tính cho sản phẩm chi tiết
        /// </summary>
        /// <param name="idSanPhamChiTiet"></param>
        /// <param name="listIdThuocTinhGiaTri"></param>
        /// <param name="username"></param>
        public void AddSanPhamChiTietThuocTinh(int idSanPhamChiTiet, List<int> listIdThuocTinhGiaTri , string username)
        {
            _logger.LogInformation($"{nameof(AddSanPhamChiTietThuocTinh)}: idSanPhamChiTiet={idSanPhamChiTiet}; listIdThuocTinhGiaTri={JsonSerializer.Serialize(listIdThuocTinhGiaTri)}; username={username}");

            var now = DateTime.Now;
            foreach (var item in listIdThuocTinhGiaTri)
            { 
                _globalAIDbContext.SanPhamChiTietThuocTinhs.Add(new SanPhamChiTietThuocTinh
                {
                    IdSanPhamChiTiet = idSanPhamChiTiet,
                    IdThuocTinhGiaTri = item,
                    CreatedBy = username,
                    CreatedDate = now
                });
            }
        }

    }
}
