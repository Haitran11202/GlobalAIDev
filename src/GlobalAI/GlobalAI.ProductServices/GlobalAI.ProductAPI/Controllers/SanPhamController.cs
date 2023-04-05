using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DemoProduct;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class SanPhamController : BaseController
    {
        private readonly ISanPhamServices _sanPhamServices;
        public SanPhamController(ISanPhamServices sanPhamServices) 
        {
            _sanPhamServices = sanPhamServices;
        }
        [HttpPost("them-san-pham")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.AddSanPham(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        [HttpPut("sua-san-pham/{id}")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Put(int id,[FromBody] AddSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.PutSanPham(id, input);
                if (result != null)
                {
                    return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
                }
                else
                {
                    return new APIResponse(Utils.StatusCode.Error, result, 404, "Not Found");
                }
                
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
