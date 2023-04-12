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
    [Route("api/product/giohang")]
    [ApiController]
    public class GioHangController : BaseController
    {
        private readonly IGioHangServices _gioHangServices;

        public GioHangController(IGioHangServices gioHangServices)
        {
            _gioHangServices = gioHangServices;
        }


        [HttpPost]
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
        /// <param name="id">Mã GSaler </param>
        /// <param name="maSanPham">Mã sản phẩm</param>
        /// <param name="newGioHang"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<EditGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse EditGioHang([FromRoute]int id, int maSanPham, EditGioHangDto newGioHang)
        {
            try
            {
                var gioHang = _gioHangServices.EditGiohang(id ,maSanPham, newGioHang);
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
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<AddGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse DeleteGioHang([FromQuery] int maGSaler, int maSanPham )
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
