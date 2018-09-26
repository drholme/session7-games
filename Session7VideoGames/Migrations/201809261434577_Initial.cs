namespace Session7VideoGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Playable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Rating = c.String(),
                        Developer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameCharacters",
                c => new
                    {
                        Game_Id = c.Int(nullable: false),
                        Character_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.Character_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.Character_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.PlatformGames",
                c => new
                    {
                        Platform_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_Id, t.Game_Id })
                .ForeignKey("dbo.Platforms", t => t.Platform_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Platform_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatformGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.PlatformGames", "Platform_Id", "dbo.Platforms");
            DropForeignKey("dbo.Games", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.GameCharacters", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.GameCharacters", "Game_Id", "dbo.Games");
            DropIndex("dbo.PlatformGames", new[] { "Game_Id" });
            DropIndex("dbo.PlatformGames", new[] { "Platform_Id" });
            DropIndex("dbo.GameCharacters", new[] { "Character_Id" });
            DropIndex("dbo.GameCharacters", new[] { "Game_Id" });
            DropIndex("dbo.Games", new[] { "Developer_Id" });
            DropTable("dbo.PlatformGames");
            DropTable("dbo.GameCharacters");
            DropTable("dbo.Platforms");
            DropTable("dbo.Developers");
            DropTable("dbo.Games");
            DropTable("dbo.Characters");
        }
    }
}
