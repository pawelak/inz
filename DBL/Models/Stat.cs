using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DBL.Interfaces;

namespace DBL.Models
{
    public class Stat : IEntity
    {
        [Key, ForeignKey("Word")]
        public int Id { get; set; }
        public int YesCounter { get; set; }
        public int NoCounter { get; set; }
        public DateTime LastUsage { get; set; }
        public DateTime NextUsage { get; set; }
        public int KnowLevel { get; set; }
        public int LastAnswer { get; set; }

        public virtual Word Word { get; set; }

        public Stat()
        {
            YesCounter = 0;
            NoCounter = 0;
            LastUsage = DateTime.Now;
            NextUsage = DateTime.Now;
            KnowLevel = 0;
        }
        public Stat(Word word)
        {
            YesCounter = 0;
            NoCounter = 0;
            LastUsage = DateTime.Now;
            NextUsage = DateTime.Now;
            KnowLevel = 0;
            Word = word;
        }

    }
}