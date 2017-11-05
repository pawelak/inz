using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using DBL.Interfaces;

namespace DBL.Models
{
    public class User : IEntity
    {
            [Key]
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Name { get; set; }


            public virtual ICollection<Deck> Decks { get; set; }
            public virtual ICollection<Stat> Stats { get; set; }

    }
}