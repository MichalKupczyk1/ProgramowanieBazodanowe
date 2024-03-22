using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IUserInterface
    {
        public bool UserLogIn(string username, string password);
        public bool UserLogOut(int UserId);
        public List<UserGroupResponseDTO> GetUsers();
        public UserResponseDTO GetUser(int id);
    }
}
