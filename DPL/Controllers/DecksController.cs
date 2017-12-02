using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.ModelsDTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DPL.Controllers
{
    public class DecksController : ApiController
    {
        readonly DecksService _decksService = new DecksService();


        // GET: api/Decks/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>list of Decks</returns>
        public List<DeckDto> Get(string email)
        {
            var result = _decksService.GetDecks(email);
            return result;
        }

        
        public DeckDto Get(int deckId)
        {
            return _decksService.GetInfo(deckId);
        }


        // POST: api/Decks
        public int Post([System.Web.Http.FromBody]DeckDto deckDto, string email)
        {
            return _decksService.UpdateDeck(email, deckDto);
        }

        // PUT: api/Decks/5
        public DeckDto Put([System.Web.Http.FromBody]DeckDto deckDto, string email)
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
