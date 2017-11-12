using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.ModelsDTO;
using BLL.Services;
using DBL.Repositories;

namespace DPL.Controllers
{
    public class UserController : ApiController
    {
        UserService _userService = new UserService();

        // GET api/User?email=string&password=string
        public bool Get(string email, string password)
        {
            return _userService.AcceptPassword(password, email);
        }

        public bool Get(string email)
        {
            return _userService.UserExist(email);
        }

        // POST api/User
        public IHttpActionResult Post([FromBody] UserDto userDto)
        {
            // var response = Request.CreateResponse(HttpStatusCode.OK, "value");


            return Ok();
        }
    }
}
