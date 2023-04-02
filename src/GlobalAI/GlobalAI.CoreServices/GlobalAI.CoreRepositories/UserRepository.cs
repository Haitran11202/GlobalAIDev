
//using GlobalAI.DataAccess.Base;
//using GlobalAI.DataAccess.Base;
//using GlobalAI.DataAccess.Base;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.DataAccess.Base;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.CoreRepositories
{
    public class UserRepository : BaseEFRepository<User>
    {
        public UserRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        /// <summary>
        /// Tạo mới user
        /// </summary>
        /// <param name="entity"></param>
        public void AddUser(User entity)
        {
            _logger.LogInformation($"{nameof(AddUser)}: entity = {JsonSerializer.Serialize(entity)}");

            entity.CreatedDate = DateTime.Now;
            entity.Password = CommonUtils.CreateMD5(entity.Password);

            _globalAIDbContext.Users.Add(entity);
        }

        /// <summary>
        /// Tìm theo username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User FindByUsername(string username)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: username = {username}");

            return _globalAIDbContext.Users.AsNoTracking().FirstOrDefault(x => x.Username == username && !x.Deleted);
        }

        /// <summary>
        /// Tìm theo email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User FindByEmail(string email)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: email = {email}");

            return _globalAIDbContext.Users.AsNoTracking().FirstOrDefault(x => x.Email == email && !x.Deleted);
        }

        /// <summary>
        /// Tìm theo sdt
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public User FindByPhone(string phone)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: phone = {phone}");

            return _globalAIDbContext.Users.AsNoTracking().FirstOrDefault(x => x.Phone == phone && !x.Deleted);
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string username, string password)
        {
            _logger.LogInformation($"{nameof(ValidateUser)} -> {nameof(User)}: username={username}, password={password}");

            string encryptedPassword = CommonUtils.CreateMD5(password);
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Username == username && x.Password == encryptedPassword && !x.Deleted);
        }
    }
}
