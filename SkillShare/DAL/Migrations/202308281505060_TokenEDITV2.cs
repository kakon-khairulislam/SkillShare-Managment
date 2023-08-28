namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenEDITV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "Username", "dbo.Instructors");
            AddForeignKey("dbo.Tokens", "Username", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            AddForeignKey("dbo.Tokens", "Username", "dbo.Instructors", "InstructorId", cascadeDelete: true);
        }
    }
}
