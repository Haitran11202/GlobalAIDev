using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Route("api/gio-hang")]
    [ApiController]
    public class GioHangController : BaseController
    {
        private readonly IGioHangServices _gioHangServices;

        public GioHangController(IGioHangServices gioHangServices)
        {
            _gioHangServices = gioHangServices;
        }


        [HttpPost("them")]
        [ProducesResponseType(typeof(APIResponse<List<AddGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateGioHang([FromQuery] AddGioHangDto input)
        {
            try
            {
                _gioHangServices.CreateGiohang(input);
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
        [ProducesResponseType(typeof(APIResponse<List<EditGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse EditGioHang([FromRoute]int id, string maSanPham, EditGioHangDto newGioHang)
        {
            try
            {
                var gioHang = _gioHangServices.EditGiohang(id,maSanPham, newGioHang);
                if (gioHang == null)
                {
                    return new APIResponse(Utils.StatusCode.Success, null, 404, "Not Found");
                }    
                return new APIResponse(Utils.StatusCode.Success, gioHang, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        [HttpDelete("xoa")]
        [ProducesResponseType(typeof(APIResponse<List<AddGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse DeleteGioHang([FromQuery] int maGSaler, string maSanPham )
        {
            try
            {
                var result = _gioHangServices.DeleteGiohang(maGSaler,maSanPham);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
