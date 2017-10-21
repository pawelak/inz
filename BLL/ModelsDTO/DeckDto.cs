using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ModelsDTO
{
    public class DeckDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decdescription { get; set; }
        public int NumberOfWords { get; set; }
    }
}