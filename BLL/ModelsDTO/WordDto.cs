using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ModelsDTO
{
    public class WordDto
    {
        public int Id { get; set; }
        public string Word1 { get; set; }
        public string Word2 { get; set; }
        public int IdStat { get; set; }
        public int YesCounter { get; set; }
        public int NoCounter { get; set; }
        public DateTime LastUsage { get; set; }
        public int KnowLevel { get; set; }
        public int LastAnswer { get; set; }
        public bool Started { get; set; }
        public DateTime NextUsage { get; set; }

        public WordDto()
        {
        }

        public WordDto(int id, string word1, string word2, int idStat, int yesCounter, int noCounter, DateTime lastUsage, int knowLevel, int lastAnswer, bool started, DateTime nextUsage)
        {
            Id = id;
            Word1 = word1;
            Word2 = word2;
            IdStat = idStat;
            YesCounter = yesCounter;
            NoCounter = noCounter;
            LastUsage = lastUsage;
            KnowLevel = knowLevel;
            LastAnswer = lastAnswer;
            Started = started;
            NextUsage = nextUsage;
        }
    }
}