using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.ModelsDTO;
using BLL.Services;

namespace DPL.Controllers
{
    public class GameModuleController : ApiController
    {
        GameModuleService _gameService = new GameModuleService();

//        // GET: api/GameModule
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

        // GET: api/GameModule/5
        public WordDto Get(int id, string email)
        {
            return _gameService.RandWord(id, email);
        }

        // POST: api/GameModule
        public int Post(string email, [FromBody] WordDto wordDto)
        {
            return _gameService.WordResult(email, wordDto);
        }

        // PUT: api/GameModule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GameModule/5
        public void Delete(int id)
        {
        }
    }
}
