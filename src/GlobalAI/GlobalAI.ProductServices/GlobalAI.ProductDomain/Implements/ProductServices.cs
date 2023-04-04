using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DemoProduct;
using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.EntitiesBase.Dto;
using GlobalAI.ProductDomain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class ProductServices : IProductServices
    {
        private readonly GlobalAIDbContext _dbContext;
        //private readonly IMapper _mapper;
        private readonly ILogger<ProductServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DemoProductRepository _demoProductRepository;

        public ProductServices(
            GlobalAIDbContext dbContext,
            DatabaseOptions databaseOptions,
            //IMapper mapper,
            ILogger<ProductServices> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _dbContext = dbContext;
            //_mapper = mapper;
            _logger = logger;
            _connectionString = databaseOptions.ConnectionString;
            _httpContext = httpContextAccessor;
            _demoProductRepository = new DemoProductRepository(dbContext, logger);
        }

        public Product Add(AddDemoProductDto dto)
        {
            throw new NotImplementedException();
        }

        public PagingResult<AddProductDto> FindAll(FindDemoProductDto input)
        {
            throw new NotImplementedException();
        }

        AddProductDto IProductServices.Add(AddDemoProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
