using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.Utils.Controllers;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/bai-tin")]
    [ApiController]
    public class DanhMucBaiTinController : BaseController
    {
        public readonly IDanhMucBaiTinServices _danhMucBaiTinServices;

        public DanhMucBaiTinController(IDanhMucBaiTinServices danhMucBaiTinServices)
        {
            _danhMucBaiTinServices = danhMucBaiTinServices;
        }
        /// <summary>
        /// Người mua tạo giỏ hàng và 1 lân trả giá chi tiết
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] CreateDanhMucBaiTin input)
        {
            try
            {
                var result = _danhMucBaiTinServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpDelete("")]
        public void Delete(int id)
        {
            _danhMucBaiTinServices.Delete(id);
        }

        /// <summary>
        /// danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<DanhMucBaiTinDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterDanhMucBaiTinDto input)
        {
            try
            {
                var result = _danhMucBaiTinServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// chi tiet 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.OK)]
        public APIResponse GetById(int id)
        {
            try
            {
                var result = _danhMucBaiTinServices.GetById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
