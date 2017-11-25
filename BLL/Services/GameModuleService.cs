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
        public WordDto RandWord(int idDeck, string email)
        {

            var listOfWords = _uow.Repository<Deck>().GetById(idDeck);
            if (listOfWords.Words.Count <= 0 && !listOfWords.User.Email.Equals(email))
            {
                return null;
            }
            Word resultWrod;
            try
            {
                resultWrod = listOfWords.Words.Where(a => a.Started && a.Stat.NextUsage < DateTime.Now)
                    .OrderBy(d => d.Stat.NextUsage).First();
            }
            catch (Exception e)
            {
                // ignored
            }

            resultWrod = listOfWords.Words.FirstOrDefault(a => a.Started == false);
            if (resultWrod == null) return null;

            return new WordDto()
            {
                Id = resultWrod.Id,
                Word1 = resultWrod.Word1,
                Word2 = resultWrod.Word2,
                Language1 = resultWrod.Language1,
                Language2 = resultWrod.Language2,
                Started = resultWrod.Started,
                IdStat = resultWrod.Stat.Id,
                NoCounter = resultWrod.Stat.NoCounter,
                YesCounter = resultWrod.Stat.YesCounter,
                KnowLevel = resultWrod.Stat.KnowLevel,
                LastAnswer = resultWrod.Stat.LastAnswer,
                LastUsage = resultWrod.Stat.NextUsage
            };
        }

        public bool WordResult(string email, WordDto wordDto)
        {
            var word = _uow.Repository<Word>().FindById(wordDto.Id);
            if (!word.Deck.User.Email.Equals(email)) return false;
            word.Started = wordDto.Started = wordDto.Started;
            word.Word1 = wordDto.Word1;
            word.Word2 = wordDto.Word2;


            int newKnowLvl;
            int lastAns;
            DateTime nextUsage;
            var stat = _uow.Repository<Stat>().FindById(wordDto.IdStat);
            NextUsage(stat.KnowLevel, wordDto.KnowLevel, out nextUsage, out newKnowLvl, out lastAns);
            stat.KnowLevel = newKnowLvl;
            stat.NextUsage = nextUsage;
            stat.LastUsage = DateTime.Now;
            stat.NoCounter = wordDto.NoCounter;
            stat.YesCounter = wordDto.YesCounter;
            stat.LastAnswer = lastAns;

            try
            {
                _uow.Repository<Stat>().Attach(stat);
                _uow.Repository<Stat>().Save();

                _uow.Repository<Word>().Attach(word);
                _uow.Repository<Word>().Save();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public void NextUsage(int knowOld, int knowNew,  out DateTime newDate, out int newLvl, out int lastAns)
        {
            switch (knowOld)
            {
                case 15:
                    if (knowOld > knowNew)
                    {
                        newLvl = 0;
                        newDate = DateTime.Now.AddMinutes(1);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 15;
                        newDate = DateTime.Now.AddMinutes(7);
                        lastAns = 1;
                    }
                    break;
                case 30:
                    if (knowOld > knowNew)
                    {
                        newLvl = knowOld-15;
                        newDate = DateTime.Now.AddMinutes(5);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 15;
                        newDate = DateTime.Now.AddDays(1);
                        lastAns = 1;
                    }
                    break;
                case 45:
                    if (knowOld > knowNew)
                    {
                        newLvl = knowOld - 15;
                        newDate = DateTime.Now.AddMinutes(5);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 15;
                        newDate = DateTime.Now.AddDays(3);
                        lastAns = 1;
                    }
                    break;
                case 60:
                    if (knowOld > knowNew)
                    {
                        newLvl = knowOld - 30;
                        newDate = DateTime.Now.AddMinutes(5);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 15;
                        newDate = DateTime.Now.AddDays(7);
                        lastAns = 1;
                    }
                    break;
                case 75:
                    if (knowOld > knowNew)
                    {
                        newLvl = knowOld - 30;
                        newDate = DateTime.Now.AddMinutes(5);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 15;
                        newDate = DateTime.Now.AddMonths(1);
                        lastAns = 1;
                    }
                    break;
                case 90:
                    if (knowOld > knowNew)
                    {
                        newLvl = 30;
                        newDate = DateTime.Now.AddMinutes(5);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 10;
                        newDate = DateTime.Now.AddMonths(3);
                        lastAns = 1;
                    }
                    break;
                case 100:
                    if (knowOld > knowNew)
                    {
                        newLvl = 60;
                        newDate = DateTime.Now.AddDays(1);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = knowOld + 1;
                        newDate = DateTime.Now.AddMonths(6);
                        lastAns = 1;
                    }
                    break;
                case 101:
                    if (knowOld > knowNew)
                    {
                        newLvl = 60;
                        newDate = DateTime.Now.AddDays(1);
                        lastAns = -1;
                    }
                    else
                    {
                        newLvl = 101;
                        newDate = DateTime.Now.AddMonths(6);
                        lastAns = 1;
                    }
                    break;

                default:
                    newLvl = 0;
                    newDate = DateTime.Now.AddMinutes(1);
                    lastAns = -1;
                    break;

            }
        }
    }
}