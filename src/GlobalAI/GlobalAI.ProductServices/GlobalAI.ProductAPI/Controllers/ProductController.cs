using GlobalAI.DemoDomain.Interfaces;
using GlobalAI.DemoEntities.DataEntities;
using GlobalAI.DemoEntities.Dto.DemoProduct;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.DemoAPI.Controllers
{
    [Authorize]
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductServices _ProductServices;

        public ProductController(ILogger<ProductController> logger, IProductServices ProductServices)
        {
            _logger = logger;
            _ProductServices = ProductServices;
        }

        /// <summary>
        /// Thêm demo product
        /// </summary>
        [HttpPost("add")]
        [ProducesResponseType(typeof(APIResponse<AddProductDto>), (int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddDemoProductDto input)
        {
            try
            {
                var result = _ProductServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// lấy danh sách demo product
        /// </summary>
        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<AddProductDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FindDemoProductDto input)
        {
            try
            {
                var result = _ProductServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
