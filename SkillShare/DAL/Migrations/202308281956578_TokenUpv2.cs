namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenUpv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "Username" });
            AddColumn("dbo.Tokens", "InstructorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tokens", "InstructorID");
            AddForeignKey("dbo.Tokens", "InstructorID", "dbo.Instructors", "InstructorId", cascadeDelete: true);
            DropColumn("dbo.Tokens", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "Username", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Tokens", "InstructorID", "dbo.Instructors");
            DropIndex("dbo.Tokens", new[] { "InstructorID" });
            DropColumn("dbo.Tokens", "InstructorID");
            CreateIndex("dbo.Tokens", "Username");
            AddForeignKey("dbo.Tokens", "Username", "dbo.Users", "Username");
        }
    }
}
