using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.Dto.User;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.CoreAPI.Controllers
{
    [Route("api/core/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserServices _userServices;

        public UserController(ILogger<UserController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        /// <summary>
        /// Đăng ký người dùng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddUserDto input)
        {
            try
            {
                _userServices.CreateUser(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
