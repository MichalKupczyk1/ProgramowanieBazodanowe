using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class UserResponseDTO
    {
        public string Login { get; }
        public int Type { get; }
        public UserGroupResponseDTO? Group { get; }
        public bool IsActive { get; }

        public UserResponseDTO(User user)
        {
            Login = user.Login;
            Type = (int)user.Type;
            IsActive = user.IsActive;
            Group = user.UserGroup != null ? new UserGroupResponseDTO(user.UserGroup) : null;
        }

    }

    public class UserReqestDTO
    {
        public int Id { get; }
        public string Login { get; }
        public string Password { get; }
        public UserType Type { get; }
        public int? GroupId { get; }
        public bool IsActive { get; }

        public UserReqestDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            Type = user.Type;
            GroupId = user.GroupId;
            IsActive = user.IsActive;
        }
    }
}
