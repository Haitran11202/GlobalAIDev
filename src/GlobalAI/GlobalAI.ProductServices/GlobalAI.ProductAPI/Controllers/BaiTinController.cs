using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils.Controllers;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductEntities.Dto.BaiTin;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/bai-tin")]
    [ApiController]
    public class BaiTinController : BaseController
    {
        public readonly IBaiTinServices _baiTinServices;

        public BaiTinController(IBaiTinServices traGiaServices)
        {
            _baiTinServices = traGiaServices;
        }
        /// <summary>
        /// them
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] CreateBaiTin input)
        {
            try
            {
                var result = _baiTinServices.Add(input);
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
            _baiTinServices.Delete(id);
        }

        ////[HttpPut("update")]
        ////public APIResponse Update([FromBody] UpdateTraGiaDto input)
        ////{
        ////    try
        ////    {
        ////        _baiTinServices.Update(input);
        ////        return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return OkException(ex);
        ////    }
        ////}

        /// <summary>
        /// danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<BaiTinDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterBaiTinDto input)
        {
            try
            {
                var result = _baiTinServices.FindAll(input);
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
                var result = _baiTinServices.GetById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
