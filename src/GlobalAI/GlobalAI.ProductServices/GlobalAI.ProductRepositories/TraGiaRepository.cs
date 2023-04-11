using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class TraGiaRepository : BaseEFRepository<TraGia>
    {
        private readonly IMapper _mapper;
        public TraGiaRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public TraGia Add(TraGia input)
        {
            input.CreatedDate = DateTime.Now;
            //khi nao table co truong nay thi dung
            //input.Deleted = YesNo.NO;
            return _dbSet.Add(input).Entity;
        }

        public void Update(TraGia input)
        {
            //them dieu kien sau khi co truong deleted && d.Deleted == YesNo.NO
            var bargainQuery = _dbSet.FirstOrDefault(d => d.Id == input.Id);
            bargainQuery.GiaTien = input.GiaTien;
            bargainQuery.ModifiedDate = DateTime.Now;
            bargainQuery.ModifiedBy = input.ModifiedBy;
        }

        public void Approve(TraGia input)
        {
            //them dieu kien sau khi co truong deleted && d.Deleted == YesNo.NO
            var bargainQuery = _dbSet.FirstOrDefault(d => d.Id == input.Id);
            bargainQuery.ModifiedDate = DateTime.Now;
            bargainQuery.ModifiedBy = input.ModifiedBy;
        }
    }
}
