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
    public class WordController : ApiController
    {
        WordService _wordService = new WordService();

        public string Get()
        {
            var word = new WordDto()
            {
                Word1 = "tt",
                Word2 = "tt2"
            };
            _wordService.AddWord("kolakpk@gmail.com", 1, word);
            return "poszło";
        }

        // POST: api/Word
        public int Post(string email, int deckId, [FromBody] WordDto wordDto)
        {
            return _wordService.UpdateWord(email, deckId, wordDto);
        }

        // PUT: api/Word/5
        public int Put(string email, int deckId, [FromBody]WordDto wordDto)
        {
            return _wordService.AddWord(email, deckId, wordDto);
        }

        // DELETE: api/Word/5
        public int Delete(string email, int deckId,  int wordId)
        {
            return _wordService.RemoveWord(email, deckId, wordId);
        }
    }
}
