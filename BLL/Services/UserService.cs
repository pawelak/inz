using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ModelsDTO;
using DBL.Interfaces;
using DBL.Models;
using DBL.Repositories;

namespace BLL.Services
{
    public class UserService
    {
        private UnitOfWork uow;

        public UserService()
        {
            uow = new UnitOfWork();
        }

        public bool UserExist(string email)
        {
            return uow.Repository<User>().FindBy(user => user.Email.Equals(email)).Any();
        }
        public bool AcceptPassword(string pass, string email)
        {
            return uow.Repository<User>().FindBy(u => u.Email.Equals(email) && u.Password.Equals(pass)).Any();
        }

        public string AddUser(UserDto userDto)
        {
            try
            {
                if (!UserExist(userDto.Email)) return "użytkownik znajduje się już w bazie";
                uow.Repository<User>()
                    .Insert(new User() {Name = userDto.Name, Email = userDto.Email, Firstname = userDto.Firstname});
                return null;
            }
            catch (Exception e)
            {
                return "błąd podczas tworzenia konta";
            }
        }

   



    }
}