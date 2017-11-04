using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            uow.Repository<User>().Insert(new User(){Name = "pawelak", Firstname = "Pawel"});

            return false;
        }


    }
}