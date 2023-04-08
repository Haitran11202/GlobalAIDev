using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class SanPhamController : BaseController
    {
        private readonly ISanPhamServices _sanPhamServices;
        public SanPhamController(ISanPhamServices sanPhamServices) 
        {
            _sanPhamServices = sanPhamServices;
        }
        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("them")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.AddSanPham(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("sua/{id}")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Put(int id, [FromBody] AddSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.EditSanPham(id, input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("xoa/{id}")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Delete(int id)
        {
            try
            {
                var result = _sanPhamServices.DeleteSanPham(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// lấy danh sách sản phẩm có phân trang
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(APIResponse<List<FindSanPhamDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FindSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.FindAll(input);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// lấy sản phẩm theo id
        /// </summary>
        [HttpGet("{id}")]
        /*[ProducesResponseType(typeof(APIResponse<List<GetSanPhamDto>>), (int)HttpStatusCode.OK)]*/
        public APIResponse GetById(int id)
        {
            try
            {
                var result = _sanPhamServices.GetById(id);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// lấy sản phẩm theo danh mục
        /// </summary>
        [HttpGet("danh-muc/{id}")]
        [ProducesResponseType(typeof(APIResponse<List<SanPham>>), (int)HttpStatusCode.OK)]
        public APIResponse GetByCategory(int id)
        {
            try
            {
                var result = _sanPhamServices.GetByCategory(id);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
