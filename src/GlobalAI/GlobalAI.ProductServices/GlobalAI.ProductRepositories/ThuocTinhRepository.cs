using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.ProductEntities.DataEntities;
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
    public class ThuocTinhRepository : BaseEFRepository<ThuocTinh>
    {
        public ThuocTinhRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {

        }

        /// <summary>
        /// Thêm thuộc tính
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public ThuocTinh Add(ThuocTinh entity, string username)
        {
            _logger.LogInformation($"{nameof(Add)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);

            return entity;
        }

        /// <summary>
        /// Thêm thuộc tính giá trị
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public ThuocTinhGiaTri AddGiaTri(ThuocTinhGiaTri entity, string username)
        {
            _logger.LogInformation($"{nameof(AddGiaTri)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _globalAIDbContext.ThuocTinhGiaTris.Add(entity);

            return entity;
        }

        /// <summary>
        /// Tìm thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThuocTinh FindById(int id)
        {
            _logger.LogInformation($"{nameof(FindById)} -> {nameof(ThuocTinh)}: id={id}");

            var result = _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && !x.Deleted).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductThuocTinhNotFound);
            return result;
        }

        /// <summary>
        /// Lấy list thuộc tính theo id danh mục thuộc tính
        /// </summary>
        /// <param name="idDanhMucThuoctinh"></param>
        /// <returns></returns>
        public List<ThuocTinh> FindByIdDanhMucThuocTinh(int idDanhMucThuoctinh)
        {
            _logger.LogInformation($"{nameof(FindByIdDanhMucThuocTinh)} -> {nameof(List<ThuocTinh>)}: idDanhMucThuoctinh={idDanhMucThuoctinh}");

            var query = from danhMuc in _globalAIDbContext.danhMucThuocTinhs.AsNoTracking()
                        join thuocTinh in _globalAIDbContext.ThuocTinhs.AsNoTracking() on danhMuc.Id equals thuocTinh.IdDanhMucThuocTinh
                        where !danhMuc.Deleted && !thuocTinh.Deleted
                        select thuocTinh;
            return query.ToList();
        }

        /// <summary>
        /// Lấy list giá trị theo id thuộc tính
        /// </summary>
        /// <param name="idThuocTinh"></param>
        /// <returns></returns>
        public List<ThuocTinhGiaTri> FindGiaTriByIdThuocTinh(int idThuocTinh)
        {
            _logger.LogInformation($"{nameof(FindGiaTriByIdThuocTinh)} -> {nameof(List<ThuocTinhGiaTri>)}: idThuocTinh={idThuocTinh}");

            var query = from thuocTinh in _globalAIDbContext.ThuocTinhs.AsNoTracking()
                        join giaTri in _globalAIDbContext.ThuocTinhGiaTris.AsNoTracking() on thuocTinh.Id equals giaTri.IdThuocTinh
                        where !thuocTinh.Deleted && !giaTri.Deleted
                        select giaTri;
            return query.ToList();
        }

    }
}
