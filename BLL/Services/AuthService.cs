using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBL.Models;
using DBL.Repositories;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly UnitOfWork _uow;

        public AuthService()
        {
            _uow = new UnitOfWork();
        }

        public bool UserExist(string email)
        {
            var tmp = _uow.Repository<User>().FindBy(user => user.Email.Equals(email));
            return tmp.Any();
        }

        public bool AcceptPassword(string email, string password)
        {
            var user = _uow.Repository<User>().FindBy(u => u.Email.Equals(email) && u.Password.Equals(password));
            return user.Any();
        }


        public int AccesToWord(string email, int deckId, int wordId)
        {
            var deckObj = _uow.Repository<Deck>().FindById(deckId);
            if (!deckObj.User.Email.Equals(email) && deckObj.Words.Count <= 0)
            {
                return -1;
            }
            var wordObj = _uow.Repository<Word>().FindById(wordId);
            return wordObj != null ? 1 : 0;
        }

    }
}