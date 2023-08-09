namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseSectionAndStudentGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentGroups", "CourseSectionId", "dbo.CourseSections");
            DropIndex("dbo.StudentGroups", new[] { "CourseSectionId" });
            CreateTable(
                "dbo.CourseSectionAndStudentGroups",
                c => new
                    {
                        CourseSectionAndStudentGroupId = c.Int(nullable: false, identity: true),
                        StudentGroupId = c.Int(nullable: false),
                        CourseSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseSectionAndStudentGroupId)
                .ForeignKey("dbo.CourseSections", t => t.CourseSectionId, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroupId, cascadeDelete: true)
                .Index(t => t.StudentGroupId)
                .Index(t => t.CourseSectionId);
            
            AddColumn("dbo.CourseExams", "Course_CourseId", c => c.Int());
            CreateIndex("dbo.CourseExams", "Course_CourseId");
            AddForeignKey("dbo.CourseExams", "Course_CourseId", "dbo.Courses", "CourseId");
            DropColumn("dbo.StudentGroups", "CourseSectionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentGroups", "CourseSectionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CourseExams", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseSectionAndStudentGroups", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.CourseSectionAndStudentGroups", "CourseSectionId", "dbo.CourseSections");
            DropIndex("dbo.CourseSectionAndStudentGroups", new[] { "CourseSectionId" });
            DropIndex("dbo.CourseSectionAndStudentGroups", new[] { "StudentGroupId" });
            DropIndex("dbo.CourseExams", new[] { "Course_CourseId" });
            DropColumn("dbo.CourseExams", "Course_CourseId");
            DropTable("dbo.CourseSectionAndStudentGroups");
            CreateIndex("dbo.StudentGroups", "CourseSectionId");
            AddForeignKey("dbo.StudentGroups", "CourseSectionId", "dbo.CourseSections", "CourseSectionId", cascadeDelete: true);
        }
    }
}
