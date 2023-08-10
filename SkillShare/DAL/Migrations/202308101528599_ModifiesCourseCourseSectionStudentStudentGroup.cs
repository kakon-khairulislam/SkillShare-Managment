namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiesCourseCourseSectionStudentStudentGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseStauts", c => c.String(nullable: false));
            AddColumn("dbo.CourseSections", "CourseSectionStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseSections", "CourseSectionStatus");
            DropColumn("dbo.Courses", "CourseStauts");
        }
    }
}
