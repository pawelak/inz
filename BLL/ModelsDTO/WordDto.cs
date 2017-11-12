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
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public int IdStat { get; set; }
        public int YesCounter { get; set; }
        public int NoCounter { get; set; }
        public DateTime LastUsage { get; set; }
        public double KnowLevel { get; set; }
        public int LastAnswer { get; set; }
    }
}