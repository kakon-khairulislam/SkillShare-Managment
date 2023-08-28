namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentLimitAtStudentGroupTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentGroups", "StudentLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentGroups", "StudentLimit");
        }
    }
}
