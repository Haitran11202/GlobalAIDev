using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.Utils;
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
