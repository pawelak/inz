using System;
using System.Linq;
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
            var listOfWords = _uow.Repository<Deck>().FindById(idDeck);
            if (listOfWords.Words.Count <= 0 && !listOfWords.User.Email.Equals(email))
            {
                return null;
            }
            Word resultWrod;
            try
            {
                resultWrod = listOfWords.Words.Where(a => a.Started == true && DateTime.Compare(DateTime.Now,a.Stat.NextUsage) >= 0)
                    .OrderBy(d => d.Stat.NextUsage).First();
                return new WordDto(resultWrod.Id, resultWrod.Word1, resultWrod.Word2, resultWrod.Stat.Id,
                    resultWrod.Stat.YesCounter, resultWrod.Stat.NoCounter, resultWrod.Stat.LastUsage,
                    resultWrod.Stat.KnowLevel, resultWrod.Stat.LastAnswer, resultWrod.Started,
                    resultWrod.Stat.NextUsage);
            }
            catch (Exception)   //shity but with if statement VS have a problem
            {
                // ignored
            }

            resultWrod = listOfWords.Words.FirstOrDefault(a => a.Started == false);
            if (resultWrod == null) return null;

            return new WordDto(resultWrod.Id, resultWrod.Word1, resultWrod.Word2, resultWrod.Stat.Id,
                resultWrod.Stat.YesCounter, resultWrod.Stat.NoCounter, resultWrod.Stat.LastUsage,
                resultWrod.Stat.KnowLevel, resultWrod.Stat.LastAnswer, resultWrod.Started,
                resultWrod.Stat.NextUsage);
        }

        public int WordResult(string email, WordDto wordDto)
        {
            var word = _uow.Repository<Word>().FindById(wordDto.Id);
            if (word == null)
            {
                return -1 ;
            }
            //word.Started = true;
            int newKnowLvl;
            DateTime nextUsage;
            var stat = _uow.Repository<Stat>().FindById(wordDto.Id);
            NextUsage(stat.KnowLevel, wordDto.LastAnswer, out nextUsage, out newKnowLvl);
            stat.KnowLevel = newKnowLvl;
            stat.NextUsage = nextUsage;
            stat.LastUsage = DateTime.Now;
            stat.NoCounter = wordDto.NoCounter;
            stat.YesCounter = wordDto.YesCounter;
            stat.LastAnswer = wordDto.LastAnswer;
            word.Started = true;


            try
            {
                _uow.Repository<Stat>().Edit(stat);
                _uow.Repository<Word>().Edit(word);
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }

        public void NextUsage(int knowLvl, int currentAns,  out DateTime newDate, out int newKnowLvl)
        {
            switch (knowLvl)
            {
                case 0:
                    if (currentAns <= 0)
                    {
                        newKnowLvl = 0;
                        newDate = DateTime.Now.AddMinutes(1);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 15;
                        newDate = DateTime.Now.AddMinutes(7);
                    }
                    break;
                case 15:
                    if (currentAns <= 0)
                    {
                        newKnowLvl = 0;
                        newDate = DateTime.Now.AddMinutes(1);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 15;
                        newDate = DateTime.Now.AddMinutes(7);
                    }
                    break;
                case 30:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = knowLvl-15;
                        newDate = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 15;
                        newDate = DateTime.Now.AddDays(1);
                    }
                    break;
                case 45:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = knowLvl - 15;
                        newDate = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 15;
                        newDate = DateTime.Now.AddDays(3);
                    }
                    break;
                case 60:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = knowLvl - 30;
                        newDate = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 15;
                        newDate = DateTime.Now.AddDays(7);
                    }
                    break;
                case 75:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = knowLvl - 30;
                        newDate = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 15;
                        newDate = DateTime.Now.AddMonths(1);
                    }
                    break;
                case 90:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = 30;
                        newDate = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 10;
                        newDate = DateTime.Now.AddMonths(3);
                    }
                    break;
                case 100:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = 60;
                        newDate = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        newKnowLvl = knowLvl + 1;
                        newDate = DateTime.Now.AddMonths(6);
                    }
                    break;
                case 101:
                    if (currentAns <= -1)
                    {
                        newKnowLvl = 60;
                        newDate = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        newKnowLvl = 101;
                        newDate = DateTime.Now.AddMonths(6);
                    }
                    break;

                default:
                    newKnowLvl = 0;
                    newDate = DateTime.Now.AddMinutes(1);
                    break;

            }
        }
    }
}