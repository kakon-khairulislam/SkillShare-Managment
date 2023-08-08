namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudentCourseRelatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseChapterAndStudents",
                c => new
                    {
                        CourseChapterAndStudentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseChapterId = c.Int(nullable: false),
                        CourseChapterStudentProgression = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseChapterAndStudentId)
                .ForeignKey("dbo.CourseChapters", t => t.CourseChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseChapterId);
            
            CreateTable(
                "dbo.CourseChapters",
                c => new
                    {
                        CourseChapterID = c.Int(nullable: false, identity: true),
                        CourseChapterName = c.String(nullable: false),
                        CourseChapterDescription = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseChapterID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseDescription = c.String(nullable: false),
                        CourseStartDate = c.String(nullable: false),
                        CourseFinishDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseSections",
                c => new
                    {
                        CourseSectionId = c.Int(nullable: false, identity: true),
                        CourseSectionName = c.String(nullable: false),
                        CourseSectionStudentLimit = c.Int(nullable: false),
                        MinimumStudentLimitGroup = c.Int(),
                        MaximumStudentLimitGroup = c.Int(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseSectionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseSectionAndStudents",
                c => new
                    {
                        CousrseSectionAndStudentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseSectionId = c.Int(nullable: false),
                        CourseStudentProgression = c.String(),
                    })
                .PrimaryKey(t => t.CousrseSectionAndStudentId)
                .ForeignKey("dbo.CourseSections", t => t.CourseSectionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseSectionId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        StudentEmail = c.String(nullable: false),
                        StudentPassword = c.String(nullable: false),
                        StudentPhoneNumber = c.String(nullable: false),
                        StudentStatus = c.String(nullable: false),
                        StudentAccountStatus = c.String(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentAndStudentGroups",
                c => new
                    {
                        StudentAndStudentGroupId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentAndStudentGroupId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroupId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.StudentGroupId);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        StudentGroupId = c.Int(nullable: false, identity: true),
                        StudentGroupName = c.String(nullable: false),
                        AllStudentStatus = c.String(nullable: false),
                        GroupStatus = c.String(nullable: false),
                        GroupCreationDate = c.DateTime(nullable: false),
                        CourseSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentGroupId)
                .ForeignKey("dbo.CourseSections", t => t.CourseSectionId, cascadeDelete: true)
                .Index(t => t.CourseSectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseChapterAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseChapterAndStudents", "CourseChapterId", "dbo.CourseChapters");
            DropForeignKey("dbo.CourseChapters", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseSectionAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentAndStudentGroups", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.StudentGroups", "CourseSectionId", "dbo.CourseSections");
            DropForeignKey("dbo.StudentAndStudentGroups", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseSectionAndStudents", "CourseSectionId", "dbo.CourseSections");
            DropForeignKey("dbo.CourseSections", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentGroups", new[] { "CourseSectionId" });
            DropIndex("dbo.StudentAndStudentGroups", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentAndStudentGroups", new[] { "StudentId" });
            DropIndex("dbo.CourseSectionAndStudents", new[] { "CourseSectionId" });
            DropIndex("dbo.CourseSectionAndStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseSections", new[] { "CourseId" });
            DropIndex("dbo.CourseChapters", new[] { "CourseId" });
            DropIndex("dbo.CourseChapterAndStudents", new[] { "CourseChapterId" });
            DropIndex("dbo.CourseChapterAndStudents", new[] { "StudentId" });
            DropTable("dbo.StudentGroups");
            DropTable("dbo.StudentAndStudentGroups");
            DropTable("dbo.Students");
            DropTable("dbo.CourseSectionAndStudents");
            DropTable("dbo.CourseSections");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseChapters");
            DropTable("dbo.CourseChapterAndStudents");
        }
    }
}
