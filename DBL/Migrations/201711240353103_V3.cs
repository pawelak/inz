namespace DBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deck",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Decdescription = c.String(),
                        NumberOfWords = c.Int(nullable: false),
                        Public = c.Boolean(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word1 = c.String(),
                        Word2 = c.String(),
                        Language1 = c.String(),
                        Language2 = c.String(),
                        Started = c.Boolean(nullable: false),
                        Deck_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deck", t => t.Deck_Id, cascadeDelete: true)
                .Index(t => t.Deck_Id);
            
            CreateTable(
                "dbo.Stat",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        YesCounter = c.Int(nullable: false),
                        NoCounter = c.Int(nullable: false),
                        LastUsage = c.DateTime(nullable: false),
                        NextUsage = c.DateTime(nullable: false),
                        KnowLevel = c.Int(nullable: false),
                        LastAnswer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Word", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deck", "User_Id", "dbo.User");
            DropForeignKey("dbo.Word", "Deck_Id", "dbo.Deck");
            DropForeignKey("dbo.Stat", "Id", "dbo.Word");
            DropIndex("dbo.Stat", new[] { "Id" });
            DropIndex("dbo.Word", new[] { "Deck_Id" });
            DropIndex("dbo.Deck", new[] { "User_Id" });
            DropTable("dbo.Stat");
            DropTable("dbo.Word");
            DropTable("dbo.Deck");
            DropTable("dbo.User");
        }
    }
}
