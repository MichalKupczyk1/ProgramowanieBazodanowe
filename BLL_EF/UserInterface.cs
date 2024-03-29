﻿using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class UserInterface : IUserInterface
    {
        private readonly WebshopContext dbContext;
        public UserInterface(WebshopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserResponseDTO GetUser(int id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return new UserResponseDTO(user);
            }
            return null;
        }

        public List<UserGroupResponseDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UserLogIn(string username, string password)
        {
            return dbContext.Users?.FirstOrDefault(x => x.Login == username && x.Password == password) != null;
        }

        public bool UserLogOut(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
