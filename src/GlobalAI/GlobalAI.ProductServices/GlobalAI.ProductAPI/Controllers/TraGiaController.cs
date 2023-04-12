using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAI.ProductAPI.Controllers
{
    [Route("api/tragia")]
    [ApiController]
    public class TraGiaController : BaseController
    {
        public readonly ITraGiaServices _traGiaServices;

        public TraGiaController(ITraGiaServices traGiaServices)
        {
            _traGiaServices = traGiaServices;
        }

        [HttpPost("add")]
        /*public APIResponse CreateTraGia([FromQuery] AddTraGiaDto addTraGiaDto, IHttpContextAccessor httpContextAccessor)*/
        public APIResponse CreateTraGia([FromQuery] AddTraGiaDto addTraGiaDto)
        {
            try
            {
                _traGiaServices.Add(addTraGiaDto);
                return new APIResponse(Utils.StatusCode.Success, addTraGiaDto, 200, "Ok");
            } catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
