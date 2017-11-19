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
        private UnitOfWork uow;

        public DecksService()
        {
            uow = new UnitOfWork();
        }

        public List<DeckDto> GetDecks(string email)
        {
            var tmp = uow.Repository<Deck>().FindBy(d => d.User.Email.Equals(email)).ToList();
            if (tmp.Count == 0)
            {
                tmp = uow.Repository<Deck>().FindBy(d => d.Public).ToList();
            }
            return tmp.Select(el => new DeckDto() {Name = el.Name, Decdescription = el.Decdescription, Public = el.Public}).ToList();
        }
    }
}