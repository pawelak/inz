using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DBL.Enum;

namespace DBL.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        public string Word1 { get; set; }
        public string Wrod2 { get; set; }
        public LanguageEnum Language1 { get; set; }
        public LanguageEnum Language2 { get; set; }

        public Deck Deck { get; set; }
        public Stat Stat { get; set; }


    }
}