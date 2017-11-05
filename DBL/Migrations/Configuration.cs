using DBL.Enum;
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
            ContextKey = "DBL.DataContext";
        }

        protected override void Seed(DataContext context)
        {

            //users
            context.GetDbSet<User>().AddOrUpdate(new User() { Id = 1, Name = "admin", Firstname = "pawel" });

            //Stat

            //Decks
            context.GetDbSet<Deck>().AddOrUpdate(new Deck() {Id = 1, Name = "ang 1", Decdescription = "talia ogólna ang", Public = true});

            //Words
            context.GetDbSet<Word>().AddOrUpdate(new Word(){ Id = 1, Language1 = LanguageEnum.pl, Language2 = LanguageEnum.en, Word1 = "dom", Wrod2 = "home"});


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
