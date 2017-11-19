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
            var h = uow.Repository<User>().FindBy(user => user.Email.Equals(email));
            var h2 = h.ToList();
            return h.Any();
        }
        public bool AcceptPassword(string email, string pass)
        {
            var user = uow.Repository<User>().FindBy(u => u.Email.Equals(email) && u.Password.Equals(pass));
            var h = user.ToList();
            return user.Any();
         }

        public string AddUser(UserDto userDto)
        {
            try
            {
                if (UserExist(userDto.Email))
                {
                    return "użytkownik znajduje się już w bazie";
                }
                uow.Repository<User>()
                    .Insert(new User() {Email = userDto.Email, Name = userDto.Login, Password = userDto.Password});
                return "konto utworzone";
            }
            catch (Exception e)
            {
                return "błąd podczas tworzenia konta";
            }
        }

    }
}