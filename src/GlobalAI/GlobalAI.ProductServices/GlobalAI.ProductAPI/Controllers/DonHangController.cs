using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
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
        public APIResponse FindAll()
        {
            try
            {
                var result = _donHangServices.FindAll();
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);  
            }
        }
    }
}
