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
    /// <summary>
    /// controler responsible for all segment related with wordDto
    /// </summary>
    public class WordController : ApiController
    {
        readonly WordService _wordService = new WordService();
        readonly DecksService _decksService = new DecksService();

        /// <summary>
        /// Geting a list of Words in deck
        /// </summary>
        /// <param name="email"></param>
        /// <param name="deckId"></param>
        /// <returns></returns>
        public List<WordDto> Get(string email, int deckId)
        {
            return _decksService.GetListOfWords(email, deckId);
        }


        // POST: api/Word
        /// <summary>
        /// is editing word but you can change just word content
        /// </summary>
        /// <param name="email"></param>
        /// <param name="deckId"></param>
        /// <param name="wordDto"></param>
        /// <returns></returns>
        public int Post(string email, int deckId, [FromBody] WordDto wordDto)
        {
            return _wordService.UpdateWord(email, deckId, wordDto);
        }

        // PUT: api/Word/5
        /// <summary>
        /// is adding new element
        /// </summary>
        /// <param name="email"></param>
        /// <param name="deckId"></param>
        /// <param name="wordDto"></param>
        /// <returns></returns>
        public WordDto Put(string email, int deckId, [FromBody]WordDto wordDto)
        {
            return _wordService.AddWord(email, deckId, wordDto);
        }

        // DELETE: api/Word/5
        /// <summary>
        /// deleting alement
        /// </summary>
        /// <param name="email"></param>
        /// <param name="deckId"></param>
        /// <param name="wordId"></param>
        /// <returns></returns>
        public int Delete(string email, int deckId,  int wordId)
        {
            return _wordService.RemoveWord(email, deckId, wordId);
        }
    }
}
