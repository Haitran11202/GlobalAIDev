using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils
{
    public enum ErrorCode
    {
        System = 101,

        NotFound = 1404,
        BadRequest = 1400,

        InternalServerError = 1500,
        /// <summary>
        /// Danh cho các lỗi về http request
        /// </summary>
        HttpRequestException = 1501,
        NotHaveClaim = 1502,
        DbUpdateException = 1503,
        GetRequestService = 1504,
        /// <summary>
        /// Request timeout sang bên thứ 3
        /// </summary>
        HttpRequestTimeOut = 1505,
        /// <summary>
        /// lỗi logic api bên thứ 3
        /// </summary>
        HttpRequestThirdPartDomainError = 1506,

        ///user
        UserUsernameDuplicated = 1001,
        UserEmailDuplicated = 1002,
        UserPhoneDuplicated = 1003,
        UserLoginNotFound = 1004,

        /// file
        FileExtensionNoAllow = 5001,
        FileUploadNoContent = 5002,
        FileOverUploadLimit = 5003
    }

}
