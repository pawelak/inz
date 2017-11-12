using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            public string Email { get; set; }
            public string Password { get; set; }


            public virtual ICollection<Deck> Decks { get; set; }


    }
}