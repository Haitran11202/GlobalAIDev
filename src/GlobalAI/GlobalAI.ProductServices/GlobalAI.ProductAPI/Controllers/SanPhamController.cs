
﻿
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
        /// lấy danh sách sản phẩm có phân trang
        /// </summary>
        [HttpGet("find-all")]
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
        [ProducesResponseType(typeof(APIResponse<List<GetSanPhamDto>>), (int)HttpStatusCode.OK)]
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
        [HttpGet("category/{id}")]
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