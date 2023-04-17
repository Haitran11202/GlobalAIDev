using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/tra-gia")]
    [ApiController]
    public class TraGiaController : BaseController
    {
        public readonly ITraGiaServices _traGiaServices;

        public TraGiaController(ITraGiaServices traGiaServices)
        {
            _traGiaServices = traGiaServices;
        }
        /// <summary>
        /// Tạo giỏ hàng và 1 lân trả giá chi tiết
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] AddTraGiaDto input)
        {
            try
            {
                var result = _traGiaServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// sau khi có trả giá thì thêm chi tiết trả giá
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("add-detail")]
        public APIResponse AddDetail([FromBody] AddChiTietTraGiaDto input)
        {
            try
            {
                var result = _traGiaServices.AddDetail(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        //[HttpPut("update")]
        //public APIResponse Update([FromBody] UpdateTraGiaDto input)
        //{
        //    try
        //    {
        //        _traGiaServices.Update(input);
        //        return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
        //    }
        //    catch (Exception ex)
        //    {
        //        return OkException(ex);
        //    }
        //}

        //[HttpPut("approve")]
        //public APIResponse Approve([FromBody] ApproveTraGiaDto input)
        //{
        //    try
        //    {
        //        _traGiaServices.Approve(input);
        //        return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
        //    }
        //    catch (Exception ex)
        //    {
        //        return OkException(ex);
        //    }
        //}

        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<TraGiaDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterTraGiaDto input)
        {
            try
            {
                var result = _traGiaServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
