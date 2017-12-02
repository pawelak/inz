using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.ModelsDTO;
using BLL.Services;
using DBL.Repositories;
using Microsoft.SqlServer.Server;

namespace DPL.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService = new UserService();
        private readonly AuthService _authService = new AuthService();


        public string Get()
        {
            return "welcome in WebAPI";
        }

        // GET api/User?email=string&password=string
        public bool Get(string email,string password)
        {
            return _authService.AcceptPassword(email, password);
        }

        public bool Get(string email)
        {
            return _authService.UserExist(email);
        }

        // POST api/User
        public IHttpActionResult Put([FromBody] UserDto userDto)
        {
            var c = _userService.AddUser(userDto);
            return Ok(c);
        }

        public IHttpActionResult Post(string email, string name)
        {
            var c = _userService.EditName(email, name);
;            return Ok(c);
        }

        public IHttpActionResult Post(string email, string passwordO, string passwordN)
        {
            var c = _userService.EditPassword(email, passwordO, passwordN);
            return Ok(c);
        }
    }
}
