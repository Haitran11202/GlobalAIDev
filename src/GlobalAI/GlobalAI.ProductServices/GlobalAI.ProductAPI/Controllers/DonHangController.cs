using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/donhang")]
    [ApiController]
    public class DonHangController : BaseController
    {
        private readonly IDonHangServices _donHangServices;

        public DonHangController(IDonHangServices donHangServices)
        {
            _donHangServices = donHangServices;
        }

        [HttpGet]
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
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<List<AddDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHang([FromQuery] AddDonHangDto input)
        {
            try
            {
                _donHangServices.CreateDonhang(input);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<AddDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHang([FromRoute]string id, AddDonHangDto newDonHang )
        {
            try
            {
                var donHang = _donHangServices.EditDonhang(id, newDonHang);
                if ( donHang != null ) 
                {
                    return new APIResponse(Utils.StatusCode.Success, donHang, 200, "Ok");
                }
                else
                {
                    return new APIResponse(Utils.StatusCode.Error, donHang, 200, "Not Found");
                }
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse DeleteDonHangFull([FromQuery] int maDonHang)
        {
            try
            {
                _donHangServices.DeleteDonHangById(maDonHang);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpGet("full")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHangFull([FromBody]int maDonHang)
        {
            try
            {
                var input = _donHangServices.GetDonHangFull(maDonHang);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        
        [HttpPost("full")]
        [ProducesResponseType(typeof(APIResponse<AddDonHangFullDto>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHangFull([FromBody] AddDonHangFullDto addDonHangFullDto)
        {
            try
            {
                _donHangServices.CreateDonHangFull(addDonHangFullDto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
