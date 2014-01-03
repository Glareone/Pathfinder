namespace Pathfinder.Data.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Alias = c.String(maxLength:250, nullable: false),
                        Description = c.String(),
                        Filename = c.String(maxLength:250, nullable: false),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.Alias);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength:250),
                        LastName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength:250, nullable: false),
                        Password = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique:true)
                .Index(t => t.PersonId, unique:true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bots", "PersonId", "dbo.People");
            DropIndex("dbo.Bots", new[] { "PersonId" });
            DropTable("dbo.Users");
            DropTable("dbo.People");
            DropTable("dbo.Bots");
        }
    }
}
