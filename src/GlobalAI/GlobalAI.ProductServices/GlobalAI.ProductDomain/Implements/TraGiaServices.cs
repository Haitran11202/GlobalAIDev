using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class TraGiaServices : ITraGiaServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<TraGiaServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly TraGiaRepository _traGiaRepository;
        private readonly IMapper _mapper;
        public TraGiaServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<TraGiaServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _traGiaRepository = new TraGiaRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        public TraGia Add(AddTraGiaDto addTraGiaDto)
        {
            throw new NotImplementedException();
        }
        /* public TraGia Add(AddTraGiaDto addTraGiaDto, IHttpContextAccessor httpContextAccessor)*/

    }
}
