namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Difficulty", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "Tag", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Tag");
            DropColumn("dbo.Courses", "Difficulty");
        }
    }
}
