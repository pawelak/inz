﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

namespace DPL.Controllers
{
    public class ValuesController : ApiController
    {
        UserService userService = new UserService();

        // GET api/values
        public string Get()
        {
            userService.UserExist("kolakpk@gmail.com");

            return "poszlo";
        }

        // GET api/values/5
        public string Get(int id)
        {
            userService.AcceptPassword("kolakpk@gmai.com", "admin");
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
