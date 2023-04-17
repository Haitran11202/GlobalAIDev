using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Interfaces
{
    public interface IUserServices
    {
        /// <summary>
        /// Tạo user mới
        /// </summary>
        /// <param name="dto"></param>
        public void CreateUser(AddUserDto dto);
        /// <summary>
        /// Check username vs password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string username, string password);
        /// <summary>
        /// Lấy user theo username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User FindByUsername(string username);
    }
}
