using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ModelsDTO;
using DBL.Models;
using DBL.Repositories;

namespace BLL.Services
{
    public class WordService
    {
        private readonly UnitOfWork _uow;

        public WordService()
        {
            _uow = new UnitOfWork();
        }

        // ADD - you can add word just wit empty Stats
        public int AddWord(string email, int deckId, WordDto wordDto)
        {
            var deckObj = _uow.Repository<Deck>().GetById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            var stat = new Stat()
            {
                KnowLevel = 0,
                LastAnswer = 0,
                LastUsage = DateTime.Now,
                NextUsage = DateTime.Now,
                NoCounter = 0,
                YesCounter = 0


            };
            var word = new Word()
            {
                Deck = deckObj,
                Language1 = wordDto.Language1,
                Language2 = wordDto.Language2,
                Started = false,
                Stat = stat,
                Word1 = wordDto.Word1,
                Word2 = wordDto.Word2
            };
            try
            {
                _uow.Repository<Word>().Insert(word);
            }
            catch (Exception e)
            {
                return -1;
            }
            return 0;
        }

 // Update, it is jut possible to modify words fields or (in future) languages
        public int UpdateWord(string email, int deckId, WordDto wordDto)
        {
            var deckObj = _uow.Repository<Deck>().GetById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            var wordForEdit = _uow.Repository<Word>().FindById(wordDto.Id);

            wordForEdit.Word1 = wordDto.Word1;
            wordForEdit.Word2 = wordDto.Word2;
            wordForEdit.Language1 = wordDto.Language1;
            wordForEdit.Language2 = wordDto.Language2;
            try
            {
                _uow.Repository<Word>().Edit(wordForEdit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            return 0;
        }


        public int RemoveWord(string email, int deckId, int wordId)
        {
            var deckObj = _uow.Repository<Deck>().GetById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            try
            {
                _uow.Repository<Stat>().Delete(wordId);
                _uow.Repository<Word>().Delete(wordId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            
            return 0;
        }
    }
}