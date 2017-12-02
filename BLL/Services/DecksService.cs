using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ModelsDTO;
using DBL.Models;
using DBL.Repositories;

namespace BLL.Services
{
    public class DecksService
    {
        private readonly UnitOfWork _uow;
        private readonly AuthService _authService;

        public DecksService()
        {
            _authService = new AuthService();
            _uow = new UnitOfWork();
        }

        public List<DeckDto> GetDecks(string email)
        {
            var tmp = new List<Deck>();
            if (_authService.UserExist(email))
            {
                tmp = _uow.Repository<Deck>().FindBy(d => d.User.Email.Equals(email)).ToList();
                if (tmp.Count == 0)
                {
                    tmp = _uow.Repository<Deck>().FindBy(d => d.Public).ToList();
                }
            }
            return tmp.Select(el => new DeckDto(el.Id, el.Name, el.Description, el.Public)).ToList();
        }

        public DeckDto AddDeck(DeckDto deckDto, string email)
        {
            var user = _uow.Repository<User>().FindBy(u => u.Email.Equals(email)).First();
            if (user == null) return null;
            var y = _uow.Repository<Deck>().Insert(new Deck(deckDto.Name, deckDto.Description, deckDto.Public, user));
            return new DeckDto(y.Id, y.Name, y.Description, y.Public);
        }

        public List<WordDto> GetListOfWords(string email, int deckId)
        {
            var listOfWords = _uow.Repository<Deck>().FindById(deckId);
            if (listOfWords.Words.Count <= 0 && !listOfWords.User.Email.Equals(email))
            {
                return null;
            }
            var listOfDto = listOfWords.Words.Select(word => new WordDto(word.Id, word.Word1, word.Word2, word.Stat.Id,
                word.Stat.YesCounter, word.Stat.NoCounter, word.Stat.LastUsage, word.Stat.KnowLevel,
                word.Stat.LastAnswer, word.Started, word.Stat.NextUsage)).ToList();
            return listOfDto;
        }

        public int UpdateDeck(string email, DeckDto deckDto)
        {
            var deckObj = _uow.Repository<Deck>().FindById(deckDto.Id);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            if (deckObj.Public == true)
            {
                return 0;
            }
            deckObj.Description = deckDto.Description;
            deckObj.Name = deckDto.Name;
            try
            {
                _uow.Repository<Deck>().Edit(deckObj);
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }

        public int RemoveDeck(string email, int deckId)
        {
            var deckObj = _uow.Repository<Deck>().FindById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            if (deckObj.Public == true)
            {
                return 0;
            }
            foreach (var el in deckObj.Words)
            {
                _uow.Repository<Stat>().Delete(el.Id);
                _uow.Repository<Word>().Delete(el.Id);
            }
            _uow.Repository<Deck>().Delete(deckId);
            try
            {
                
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }

        public DeckDto GetInfo(int deckId)
        {
            var deckObj = _uow.Repository<Deck>().FindById(deckId);
            if (deckObj == null)
            {
                return null;
            }
            var deck = new DeckDto(deckObj.Id, deckObj.Name, deckObj.Description, deckObj.Public);

            return deck;
        }

    }


}
