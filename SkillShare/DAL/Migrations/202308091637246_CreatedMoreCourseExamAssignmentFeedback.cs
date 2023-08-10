namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedMoreCourseExamAssignmentFeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseFeedbacks",
                c => new
                    {
                        CourseFeedbackId = c.Int(nullable: false, identity: true),
                        CourseComment = c.String(nullable: false),
                        CourseRate = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseFeedbackId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.CourseSectionAssignmentAndStudents",
                c => new
                    {
                        CourseAssignmentAndStudentId = c.Int(nullable: false, identity: true),
                        StudentAssignmentStatus = c.String(nullable: false),
                        CourseAssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignmentAndStudentId)
                .ForeignKey("dbo.CourseSectionAssignments", t => t.CourseAssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseAssignmentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CourseSectionAssignments",
                c => new
                    {
                        CourseAssignmentId = c.Int(nullable: false, identity: true),
                        CourseAssignmentName = c.String(nullable: false),
                        CourseAssignmentDescription = c.String(nullable: false),
                        CourseAssignmentDueDate = c.DateTime(nullable: false),
                        CourseAssignmentStatus = c.String(nullable: false),
                        CourseSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignmentId)
                .ForeignKey("dbo.CourseSections", t => t.CourseSectionId, cascadeDelete: true)
                .Index(t => t.CourseSectionId);
            
            CreateTable(
                "dbo.CourseExamAndStudents",
                c => new
                    {
                        CourseExamAndStudentId = c.Int(nullable: false, identity: true),
                        CourseExamId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Double(),
                    })
                .PrimaryKey(t => t.CourseExamAndStudentId)
                .ForeignKey("dbo.CourseExams", t => t.CourseExamId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseExamId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CourseExams",
                c => new
                    {
                        CourseExamId = c.Int(nullable: false, identity: true),
                        CourseExamName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseFeedbacks", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseExamAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseExamAndStudents", "CourseExamId", "dbo.CourseExams");
            DropForeignKey("dbo.CourseSectionAssignmentAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseSectionAssignmentAndStudents", "CourseAssignmentId", "dbo.CourseSectionAssignments");
            DropForeignKey("dbo.CourseSectionAssignments", "CourseSectionId", "dbo.CourseSections");
            DropForeignKey("dbo.CourseFeedbacks", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseExamAndStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseExamAndStudents", new[] { "CourseExamId" });
            DropIndex("dbo.CourseSectionAssignments", new[] { "CourseSectionId" });
            DropIndex("dbo.CourseSectionAssignmentAndStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseSectionAssignmentAndStudents", new[] { "CourseAssignmentId" });
            DropIndex("dbo.CourseFeedbacks", new[] { "Student_StudentId" });
            DropIndex("dbo.CourseFeedbacks", new[] { "CourseId" });
            DropTable("dbo.CourseExams");
            DropTable("dbo.CourseExamAndStudents");
            DropTable("dbo.CourseSectionAssignments");
            DropTable("dbo.CourseSectionAssignmentAndStudents");
            DropTable("dbo.CourseFeedbacks");
        }
    }
}
