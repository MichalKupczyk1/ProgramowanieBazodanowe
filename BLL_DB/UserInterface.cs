using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class UserInterface : IUserInterface
    {
        public UserResponseDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserGroupResponseDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UserLogIn(string? username, string? password)
        {
            throw new NotImplementedException();
        }

        public bool UserLogOut(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
