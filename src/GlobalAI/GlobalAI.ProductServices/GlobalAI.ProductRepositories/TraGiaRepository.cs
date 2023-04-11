using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.ProductEntities.DataEntities;
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

        public TraGia Add(TraGia traGia)
        {
            _dbSet.Add(traGia);
            _dbContext.SaveChanges();
            return traGia;
        }
    }
}
