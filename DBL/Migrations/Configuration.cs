using System.Collections.Generic;
using DBL.Repositories;

namespace DBL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DBL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DBL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DBL.DataContext";
        }

        protected override void Seed(DataContext context)
        {
            
//            var user1 = new User()
//            {
//                Id = 1,
//                Name = "admin",
//                Firstname = "pawel",
//                Email = "kolakpk@gmail.com",
//                Password = "admin"
//            };
//            var deck1 = new Deck()
//            {
//                Id = 1,
//                Name = "ang 1",
//                Decdescription = "talia ogólna ang",
//                Public = true,
//                Users = new List<User>() {user1}
//             };
//            var stat1 = new Stat()
//            {
//                Id = 1,
//                KnowLevel = 0.0,
//                LastAnswer = 0,
//                LastUsage = DateTime.Now,
//                NextUsage = DateTime.Now,
//                NoCounter = 0,
//                YesCounter = 0,
//                User = user1
//
//            };
//            var word1 = new Word()
//            {
//                Language1 = "pl",
//                Language2 = "en",
//                Started = false,
//                Word1 = "dupa",
//                Word2 = "ass",
//                Deck = deck1,
//                Stat = stat1
//
//            };
//            context.GetDbSet<User>().AddOrUpdate(user1);
//            context.GetDbSet<Deck>().AddOrUpdate(deck1);
//            context.GetDbSet<Stat>().AddOrUpdate(stat1);
//            context.Database.Log = Console.Write;
//            if (System.Diagnostics.Debugger.IsAttached == false)
//            {
//                System.Diagnostics.Debugger.Launch();
//            }




            //users
            var user1 = new User("admin","kolakpk@gmail.com","admin");
            var user2 = new User("student","zibi@gmail.com","student");
            context.GetDbSet<User>().AddOrUpdate(user1);
            context.GetDbSet<User>().AddOrUpdate(user2);
            
            //Decks
            var deck1 = new Deck()
            {
                Id = 1,
                Name = "ang 1",
                Description = "talia ang",
                Public = true,
                User = user1
            };

            var deck2 = new Deck()
            {
                Id = 2,
                Name = "ciekawostki",
                Description = "talia adma ciekawostki",
                Public = false,
                User = user2
            };

            var deck3 = new Deck()
            {
                Id = 3,
                Name = "ang moj",
                Public = false,
                User = user2
            };
            context.GetDbSet<Deck>().AddOrUpdate(deck1);
            context.GetDbSet<Deck>().AddOrUpdate(deck2);
            context.GetDbSet<Deck>().AddOrUpdate(deck3);
            
            //Words
            var word1 = new Word()
            {
                Word1 = "dom",
                Word2 = "home",
                Deck = deck1
            };
            var stat1 = new Stat(word1);


            var word2 = new Word()
            {
                Id = 2,
                Word1 = "pies",
                Word2 = "dog",
                Deck = deck1
            };
            var stat2 = new Stat(word2);

            var word3 = new Word()
            {
                Id = 3,
                Word1 = "kot",
                Word2 = "cat",
                Deck = deck2
            };
            var stat3 = new Stat(word3);

            var word4 = new Word()
            {
                Id = 4,
                Word1 = "mysz",
                Word2 = "mouse",
                Deck = deck2
            };
            var stat4 = new Stat(word4);

            var word5 = new Word()
            {
                Id = 5,
                Word1 = "kot",
                Word2 = "cat",
                Deck = deck2
            };
            var stat5 = new Stat(word5);

            var word6 = new Word()
            {
                Id = 6,
                Word1 = "lis",
                Word2 = "fox",
                Deck = deck2
            };
            var stat6 = new Stat(word6);

            var word7 = new Word()
            {
                Id = 7,
                Word1 = "ile nóg ma pies?",
                Word2 = "4!",
                Deck = deck3
            };
            var stat7 = new Stat(word7);

            var word8 = new Word()
            {
                Id = 8,
                Word1 = "po stawie p³ywa kaczka siê nazywa co to jest?",
                Word2 = "kaczka",
                Deck = deck3
            };
            var stat8 = new Stat(word8);

            var word9 = new Word()
            {
                Id = 9,
                Word1 = "add",
                Word2 = "dodaj",
                Deck = deck3
            };
            var stat9 = new Stat(word9);

            var word10 = new Word()
            {
                Id = 10,
                Word1 = "jab³ko",
                Word2 = "apple",
                Deck = deck3
            };
            var stat10 = new Stat(word10);
            
            
            context.GetDbSet<Word>().AddOrUpdate(word1);
            context.GetDbSet<Word>().AddOrUpdate(word2);
            context.GetDbSet<Word>().AddOrUpdate(word3);
            context.GetDbSet<Word>().AddOrUpdate(word4);
            context.GetDbSet<Word>().AddOrUpdate(word5);
            context.GetDbSet<Word>().AddOrUpdate(word6);
            context.GetDbSet<Word>().AddOrUpdate(word7);
            context.GetDbSet<Word>().AddOrUpdate(word8);
            context.GetDbSet<Word>().AddOrUpdate(word9);
            context.GetDbSet<Word>().AddOrUpdate(word10);
            
            //Stat
            context.GetDbSet<Stat>().AddOrUpdate(stat1);
            context.GetDbSet<Stat>().AddOrUpdate(stat2);
            context.GetDbSet<Stat>().AddOrUpdate(stat3);
            context.GetDbSet<Stat>().AddOrUpdate(stat4);
            context.GetDbSet<Stat>().AddOrUpdate(stat5);
            context.GetDbSet<Stat>().AddOrUpdate(stat6);
            context.GetDbSet<Stat>().AddOrUpdate(stat7);
            context.GetDbSet<Stat>().AddOrUpdate(stat8);
            context.GetDbSet<Stat>().AddOrUpdate(stat9);
            context.GetDbSet<Stat>().AddOrUpdate(stat10);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

        }
    }
}
