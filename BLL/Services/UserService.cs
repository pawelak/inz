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
        private readonly UnitOfWork _uow;
        private readonly AuthService _authService;

        public UserService()
        {
            _authService = new AuthService();
            _uow = new UnitOfWork();
        }

        public string AddUser(UserDto userDto)
        {
            try
            {
                if (_authService.UserExist(userDto.Email))
                {
                    return "użytkownik znajduje się już w bazie";
                }
                _uow.Repository<User>()
                    .Insert(new User(email: userDto.Email, password: userDto.Password, name: userDto.Name) );
                return "konto utworzone";
            }
            catch (Exception e)
            {
                return "błąd podczas tworzenia konta";
            }
        }

        public string EditName(string email, string name)
        {
            try
            {
                if (_authService.UserExist(email))
                {
                    var tmp = _uow.Repository<User>().FindBy(user => user.Email.Equals(email)).First();
                    tmp.Name = name;
                    _uow.Repository<UserDto>().Edit(new UserDto(tmp.Id, tmp.Name, tmp.Email, tmp.Password));
                    return "Edytowano nazwę";
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return "błąd podczas edycji konta";
        }

        public string EditPassword(string email, string passwordO, string passwordN)
        {
            try
            {
                if (_authService.AcceptPassword(email,passwordO))
                {
                    var tmp = _uow.Repository<User>().FindBy(user => user.Email.Equals(email)).First();
                    tmp.Password = passwordN;
                    _uow.Repository<UserDto>().Edit(new UserDto(tmp.Id, tmp.Name, tmp.Email, tmp.Password));
                    return "Edytowano hasło";
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return "błąd podczas edycji hasła";
        }

    }
}