using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Route("api/ct-donhang")]
    [ApiController]
    public class ChiTietDonHangController : BaseController
    {
        private readonly IChiTietDonHangServices _chiTietDonHangServices;

        public ChiTietDonHangController(IChiTietDonHangServices chiTietDonHang)
        {
            _chiTietDonHangServices = chiTietDonHang;
        }

        //[HttpGet("lay-chi-tiet-don-hang")]
        //[ProducesResponseType(typeof(APIResponse<List<FindDonHangDto>>), (int)HttpStatusCode.OK)]
        //public APIResponse FindAll([FromQuery] FindDonHangDto input)
        //{
           
        //}
        [HttpPost("tao-chi-tiet-don-hang")]
        [ProducesResponseType(typeof(APIResponse<List<AddChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHang([FromQuery] AddChiTietDonHangDto input)
        {
            try
            {
                _chiTietDonHangServices.CreateChiTietDonhang(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
