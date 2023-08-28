namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenUp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "Username" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Tokens", "Username", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Username");
            CreateIndex("dbo.Tokens", "Username");
            AddForeignKey("dbo.Tokens", "Username", "dbo.Users", "Username");
            DropColumn("dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "Username" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Tokens", "Username", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "UserId");
            CreateIndex("dbo.Tokens", "Username");
            AddForeignKey("dbo.Tokens", "Username", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
