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
        [HttpPost("them")]
        [ProducesResponseType(typeof(APIResponse<List<AddChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateChiTietDonHang([FromQuery] AddChiTietDonHangDto input)
        {
            try
            {
                _chiTietDonHangServices.CreateChiTietDonhang(input);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Sửa đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <param name="maSanPham"></param>
        /// <param name="newDonHang"></param>
        /// <returns></returns>
        [HttpPut("sua/{id}")]
        [ProducesResponseType(typeof(APIResponse<List<AddChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse EditChiTietDonHang([FromRoute]string id, string maSanPham, EditChiTietDonHangDto newDonHang)
        {
            try
            {
                var donHang = _chiTietDonHangServices.EditChiTietDonhang(id, maSanPham, newDonHang);
                if (donHang == null)
                {
                    return new APIResponse(Utils.StatusCode.Success, null, 404, "Not Found");
                }    
                return new APIResponse(Utils.StatusCode.Success, donHang, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
