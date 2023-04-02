using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils
{
    public static class ErrorMessage
    {
        public static Dictionary<int, string> ErrorMessages = new Dictionary<int, string>()
        {
            { (int)ErrorCode.NotFound, "Not found" },
            { (int)ErrorCode.UserUsernameDuplicated, "Tên đăng nhập đã tồn tại." },
            { (int)ErrorCode.UserEmailDuplicated, "Email đã được tồn tại." },
            { (int)ErrorCode.UserPhoneDuplicated, "Số điện thoại đã tồn tại." },
            { (int)ErrorCode.UserLoginNotFound, "Tên đăng nhập hoặc mật khẩu không chính xác." },
        };

        /// <summary>
        /// Lấy error message theo error code
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static string Get(int errorCode)
        {
            ErrorMessages.TryGetValue(errorCode, out string message);
            return message ?? $"Không tìm thấy mã lỗi {errorCode}";
        }
    }

}
