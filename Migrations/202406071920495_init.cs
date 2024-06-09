namespace Dictionary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DictionaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dictionaries", t => t.DictionaryId, cascadeDelete: true)
                .Index(t => t.DictionaryId);
            
            CreateTable(
                "dbo.Translates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Translates", "WordId", "dbo.Words");
            DropForeignKey("dbo.Words", "DictionaryId", "dbo.Dictionaries");
            DropIndex("dbo.Translates", new[] { "WordId" });
            DropIndex("dbo.Words", new[] { "DictionaryId" });
            DropTable("dbo.Translates");
            DropTable("dbo.Words");
            DropTable("dbo.Dictionaries");
        }
    }
}
