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
        public void CreateUser(AddUserDto dto);
        public User ValidateUser(string username, string password);
    }
}
