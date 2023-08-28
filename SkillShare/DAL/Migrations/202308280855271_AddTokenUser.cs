namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTokenUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        TokenId = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        Username = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "Username" });
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
        }
    }
}
