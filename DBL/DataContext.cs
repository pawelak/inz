using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DBL.Interfaces;
using DBL.Models;

namespace DBL
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("name=InzDb")
        {

        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Word> Words { get; set; }
        public IDbSet<Deck> Decks { get; set; }
        public IDbSet<Stat> Stats { get; set; }


        public IDbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
