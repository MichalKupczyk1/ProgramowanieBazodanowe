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
        public string Type { get; }
        public UserGroupResponseDTO? Group { get; }
        public bool IsActive { get; }

        public UserResponseDTO(string login, string type, bool isActive, UserGroupResponseDTO group = null)
        {
            this.Login = login;
            this.Type = type;
            this.Group = group;
            this.IsActive = isActive;
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
        public UserReqestDTO(int id, string login, string password, bool isActive, UserType type, int? groupId)
        {
            Id = id;
            Login = login;
            Password = password;
            Type = type;
            GroupId = groupId;
            IsActive = isActive;
        }
    }
}
