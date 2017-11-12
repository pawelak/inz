using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DBL.Interfaces;

namespace DBL.Models
{
    public class Word : IEntity
    {

        [Key]
        public int Id { get; set; }
        public string Word1 { get; set; }
        public string Word2 { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public bool Started { get; set; }

        
        public Deck Deck { get; set; }
        public virtual Stat Stat { get; set; }



    }
}