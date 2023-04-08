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
        private readonly IMapper mapper;
        public DonHangRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {

        }
        public List<GetDonHangDto> FindAll()
        {
            return _dbSet.Select(s => mapper.Map<GetDonHangDto>(s)).ToList();
        }
    }
}