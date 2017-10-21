using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBL.Enum;

namespace BLL.ModelsDTO
{
    public class WordDto
    {
        public int Id { get; set; }
        public string Word1 { get; set; }
        public string Wrod2 { get; set; }
        public LanguageEnum Language1 { get; set; }
        public LanguageEnum Language2 { get; set; }

    }
}