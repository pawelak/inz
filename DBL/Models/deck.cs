using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBL.Models
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decdescription { get; set; }
        public int NumberOfWords { get; set; }

        public virtual ICollection<Word> Words { get; set; }
        public User User { get; set; }

    }
}