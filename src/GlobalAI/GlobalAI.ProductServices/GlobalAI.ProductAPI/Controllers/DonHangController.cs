using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Route("api/donhang")]
    [ApiController]
    public class DonHangController : BaseController
    {
        private readonly IDonHangServices _donHangServices;

        public DonHangController(IDonHangServices donHangServices)
        {
            _donHangServices = donHangServices;
        }

        [HttpGet("lay-don-hang")]
        [ProducesResponseType(typeof(APIResponse<List<FindDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FindDonHangDto input)
        {
            try
            {
                var result = _donHangServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);  
            }
        }
        [HttpPost("tao-don-hang")]
        [ProducesResponseType(typeof(APIResponse<List<AddDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHang([FromQuery] AddDonHangDto input)
        {
            try
            {
                _donHangServices.CreateDonhang(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
