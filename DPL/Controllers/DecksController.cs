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
    public class DecksController : ApiController
    {
        DecksService _decksService = new DecksService();

        // GET: api/Decks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Decks/5
        public List<DeckDto> Get(string email)
        {
            var result = _decksService.GetDecks(email);
            return result;
        }

        // POST: api/Decks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Decks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Decks/5
        public void Delete(int id)
        {
        }
    }
}
