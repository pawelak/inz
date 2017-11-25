using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        public DataContext() : base("name=FlashCards")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasMany(u => u.Decks).WithRequired(u => u.User).WillCascadeOnDelete(true);
            modelBuilder.Entity<Deck>().ToTable("Deck").HasMany(d => d.Words).WithRequired(d => d.Deck).WillCascadeOnDelete(true);
            modelBuilder.Entity<Stat>().ToTable("Stat");
            modelBuilder.Entity<Word>().ToTable("Word");
            Database.Log = (query) => Debug.Write(query); //wypisywac ma 

            base.OnModelCreating(modelBuilder);
        }


        public IDbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }


    }
}
