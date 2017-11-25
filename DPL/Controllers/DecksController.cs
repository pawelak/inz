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

        public DeckDto Get(int deckId)
        {
            return _decksService.GetInfo(deckId);
        }

        public List<WordDto> Get(string email, int deckId)
        {
            return _decksService.GetListOfWords(email, deckId);
        }


        // POST: api/Decks
        public int Post([FromBody]DeckDto deckDto, string email)
        {
            return _decksService.UpdateDeck(email, deckDto);
        }

        // PUT: api/Decks/5
        public int Put([FromBody]DeckDto deckDto, string email)
        {
            return _decksService.AddDeck(deckDto, email);
        }

        // DELETE: api/Decks/5
        public int Delete(string email, int deckId)
        {
            return _decksService.RemoveDeck(email, deckId);
        }
    }
}
