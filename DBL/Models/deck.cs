using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DBL.Interfaces;

namespace DBL.Models
{
    public class Deck : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Public { get; set; }

        public virtual ICollection<Word> Words { get; set; }
        public virtual User User { get; set; }

        public Deck()
        {
        }

        public Deck(string name, string description, bool @public, User user)
        {
            Name = name;
            Description = description;
            Public = @public;
            User = user;
            Words = new List<Word>();
        }
    }
}