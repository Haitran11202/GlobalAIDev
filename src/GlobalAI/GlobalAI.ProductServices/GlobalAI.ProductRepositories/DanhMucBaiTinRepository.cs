using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class DanhMucBaiTinRepository : BaseEFRepository<DanhMucBaiTin>
    {
        private readonly IMapper _mapper;
        public DanhMucBaiTinRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public DanhMucBaiTin Add(DanhMucBaiTin input)
        {
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = DateTime.Now;
            input.Deleted = DeletedBool.NO;
            return _dbSet.Add(input).Entity;
        }

        //public void DeleteByBaiTinId(int id, string username)
        //{
        //    if (_dbSet.Any(e => e.IdTraGia == id))
        //    {
        //        _dbSet.Where(e => e.IdTraGia == id)
        //            .ToList()
        //            .ForEach(e => {
        //                e.DeletedBy = username;
        //                e.DeletedDate = DateTime.Now;
        //                e.Deleted = true;
        //            });
        //    }
        //}

        //public DanhMucBaiTin FindById(int id)
        //{
        //    return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
        //}

        //public IQueryable<DanhMucBaiTin> GetAll(int idBaiTin)
        //{
        //    return _dbSet.Where(b => b.id == idBaiTin && b.Deleted == DeletedBool.NO);
        //}
    }
}
