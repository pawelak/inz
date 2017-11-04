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
//        public IDbSet<User> Users { get; set; }
//        public IDbSet<Word> Words { get; set; }
//        public IDbSet<Deck> Decks { get; set; }
//        public IDbSet<Stat> Stats { get; set; }

        public DataContext() : base("name=FiszkiDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Deck>().ToTable("Deck");
            modelBuilder.Entity<Stat>().ToTable("Stat");
            modelBuilder.Entity<Word>().ToTable("Word");
        }

        public IDbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
