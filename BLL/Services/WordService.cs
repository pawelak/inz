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
        public WordDto AddWord(string email, int deckId, WordDto wordDto)
        {
            var ret = new Word();
            var deckObj = _uow.Repository<Deck>().FindById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return null;
            }
            var word = new Word(wordDto.Word1, wordDto.Word2,deckObj);
            try
            {
                ret = _uow.Repository<Word>().Insert(word);
            }
            catch (Exception e)
            {
                return null;
            }
            return new WordDto(ret.Id, ret.Word1, ret.Word2, ret.Stat.Id, ret.Stat.YesCounter, ret.Stat.NoCounter,
                ret.Stat.LastUsage, ret.Stat.KnowLevel, ret.Stat.LastAnswer, ret.Started, ret.Stat.NextUsage);
        }

 // Update, it is jut possible to modify words fields or (in future) languages
        public int UpdateWord(string email, int deckId, WordDto wordDto)
        {
            var deckObj = _uow.Repository<Deck>().FindById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            var wordForEdit = _uow.Repository<Word>().FindById(wordDto.Id);
            if (wordForEdit == null)
            {
                return -1;
            }
            wordForEdit.Word1 = wordDto.Word1;
            wordForEdit.Word2 = wordDto.Word2;
            try
            {
                _uow.Repository<Word>().Edit(wordForEdit);
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }


        public int RemoveWord(string email, int deckId, int wordId)
        {
            var deckObj = _uow.Repository<Deck>().FindById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            try
            {
                _uow.Repository<Stat>().Delete(wordId);
                _uow.Repository<Word>().Delete(wordId);
            }
            catch (Exception)
            {
                return -1;
            }
            
            return 1;
        }
    }
}