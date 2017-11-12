using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ModelsDTO;
using DBL.Models;
using DBL.Repositories;

namespace BLL.Services
{
    public class GameModuleService
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        public WordDto GetWord(int idDeck, int idUser)
        {
            var listOfWords = _uow.Repository<Deck>().GetById(idDeck).Words;
            if (listOfWords.Count < 0)
            {
                return null;
            }
            var resultWrod = listOfWords.Where(a => a.Started && a.Stat.NextUsage < DateTime.Now)
                                        .OrderBy(d => d.Stat.NextUsage).First() ??
                             listOfWords.First(a => a.Started == false);
            return new WordDto()
            {
                Id = resultWrod.Id,
                Word1 = resultWrod.Word1,
                Word2 = resultWrod.Word2,
                Language1 = resultWrod.Language1,
                Language2 = resultWrod.Language2,
                IdStat = resultWrod.Stat.Id,
                NoCounter = resultWrod.Stat.NoCounter,
                YesCounter = resultWrod.Stat.YesCounter,
                KnowLevel = resultWrod.Stat.KnowLevel,
                LastAnswer = resultWrod.Stat.LastAnswer
            };
        }
    }
}