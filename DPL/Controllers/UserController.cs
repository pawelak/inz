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

        public string Get()
        {
            return "welcome in WebAPI";
        }

        // GET api/User?email=string&password=string
        public bool Get(string email,string password)
        {
            return _userService.AcceptPassword(email, password);
        }

        public bool Get(string email)
        {
            return _userService.UserExist(email);
        }

        // POST api/User
        public IHttpActionResult Post([FromBody] UserDto userDto)


        {
            var c = _userService.AddUser(userDto);
            var response = Request.CreateResponse(HttpStatusCode.OK,c);
            return Ok(c);
        }
    }
}
