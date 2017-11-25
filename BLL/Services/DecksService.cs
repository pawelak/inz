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

        public DecksService()
        {
            _uow = new UnitOfWork();
        }

        public List<DeckDto> GetDecks(string email)
        {
            var tmp = _uow.Repository<Deck>().FindBy(d => d.User.Email.Equals(email)).ToList();
            if (tmp.Count == 0)
            {
                tmp = _uow.Repository<Deck>().FindBy(d => d.Public).ToList();
            }
            return tmp.Select(el => new DeckDto() {Id = el.Id, Name = el.Name, Description = el.Decdescription, Public = el.Public}).ToList();
        }

        public int AddDeck(DeckDto deckDto, string email)
        {
            var user = _uow.Repository<User>().FindBy(u => u.Email.Equals(email)).First();
            if (user == null) return -1;
            var y = _uow.Repository<Deck>().Insert(new Deck() {Name = deckDto.Name, Public = false, User = user});
            return y.Id;
        }

        public List<WordDto> GetListOfWords(string email, int deckId)
        {
            var listOfWords = _uow.Repository<Deck>().GetById(deckId);
            if (listOfWords.Words.Count <= 0 && !listOfWords.User.Email.Equals(email))
            {
                return null;
            }
            var listOfDto = listOfWords.Words.Select(word => new WordDto()
                {
                    Id = word.Id,
                    Word1 = word.Word1,
                    Word2 = word.Word2,
                    Language1 = word.Language1,
                    Language2 = word.Language2,
                    Started = word.Started,
                    IdStat = word.Stat.Id,
                    NoCounter = word.Stat.NoCounter,
                    YesCounter = word.Stat.YesCounter,
                    KnowLevel = word.Stat.KnowLevel,
                    LastAnswer = word.Stat.LastAnswer,
                    LastUsage = word.Stat.LastUsage
                })
                .ToList();
            return listOfDto;
        }

        public int UpdateDeck(string email, DeckDto deckDto)
        {
            var deckObj = _uow.Repository<Deck>().GetById(deckDto.Id);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            deckObj.Decdescription = deckDto.Description;
            deckObj.Name = deckDto.Name;
            try
            {
                _uow.Repository<Deck>().Edit(deckObj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            return 0;
        }

        public int RemoveDeck(string email, int deckId)
        {
            var deckObj = _uow.Repository<Deck>().GetById(deckId);
            if (!deckObj.User.Email.Equals(email))
            {
                return -1;
            }
            _uow.Repository<Deck>().Delete(deckId);
            return 0;
        }

        public DeckDto GetInfo(int deckId)
        {
            var deckObj = _uow.Repository<Deck>().GetById(deckId);
            if (deckObj == null) 
            {
                return null;
            }
            var deck = new DeckDto()
            {
                Description = deckObj.Decdescription,
                Id = deckObj.Id,
                Name = deckObj.Name,
                NumberOfWords = deckObj.NumberOfWords,
                Public = deckObj.Public
            };
            return deck;
        }


        //        public bool InsertOrUpdateWord(string email, int deckId, WordDto wordDto)
        //        {
        //            var deckObj = _uow.Repository<Deck>().GetById(deckId);
        //            if (!deckObj.User.Email.Equals(email))
        //            {
        //                return false;
        //            }
        //
        //            var wordObj = _uow.Repository<Word>().InsertOrUpdate()
        //
        //        }

    }


}
