namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDBIns : DbMigration
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
                        Instructor_InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseChapterID)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.Instructor_InstructorId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseDescription = c.String(nullable: false),
                        CourseStartDate = c.String(nullable: false),
                        CourseFinishDate = c.String(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.CourseExams",
                c => new
                    {
                        CourseExamId = c.Int(nullable: false, identity: true),
                        CourseExamName = c.Int(nullable: false),
                        Course_CourseId = c.Int(),
                        Instructor_InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseExamId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Instructor_InstructorId);
            
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
                "dbo.CourseSections",
                c => new
                    {
                        CourseSectionId = c.Int(nullable: false, identity: true),
                        CourseSectionName = c.String(nullable: false),
                        CourseSectionStudentLimit = c.Int(nullable: false),
                        MinimumStudentLimitGroup = c.Int(),
                        MaximumStudentLimitGroup = c.Int(),
                        CourseId = c.Int(nullable: false),
                        Instructor_InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseSectionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId)
                .Index(t => t.CourseId)
                .Index(t => t.Instructor_InstructorId);
            
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
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        StudentGroupId = c.Int(nullable: false, identity: true),
                        StudentGroupName = c.String(nullable: false),
                        AllStudentStatus = c.String(nullable: false),
                        GroupStatus = c.String(nullable: false),
                        GroupCreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentGroupId);
            
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
                "dbo.CourseFeedbacks",
                c => new
                    {
                        CourseFeedbackId = c.Int(nullable: false, identity: true),
                        CourseComment = c.String(nullable: false),
                        CourseRate = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                        Instructor_InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseFeedbackId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Instructor_InstructorId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        InstructorName = c.String(),
                        InstructorEmail = c.String(),
                        InstructorPassword = c.String(),
                        InstructorPhoneNumber = c.String(),
                        InstructorStatus = c.String(),
                        InstructorAccountStatus = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseChapterAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseChapterAndStudents", "CourseChapterId", "dbo.CourseChapters");
            DropForeignKey("dbo.CourseChapters", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.CourseSections", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.CourseFeedbacks", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.CourseExams", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.CourseChapters", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.CourseFeedbacks", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseFeedbacks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseExams", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseExamAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseSectionAssignmentAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseSectionAssignmentAndStudents", "CourseAssignmentId", "dbo.CourseSectionAssignments");
            DropForeignKey("dbo.CourseSectionAssignments", "CourseSectionId", "dbo.CourseSections");
            DropForeignKey("dbo.CourseSectionAndStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseSectionAndStudents", "CourseSectionId", "dbo.CourseSections");
            DropForeignKey("dbo.CourseSectionAndStudentGroups", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.StudentAndStudentGroups", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.StudentAndStudentGroups", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseSectionAndStudentGroups", "CourseSectionId", "dbo.CourseSections");
            DropForeignKey("dbo.CourseSections", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseExamAndStudents", "CourseExamId", "dbo.CourseExams");
            DropIndex("dbo.CourseFeedbacks", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.CourseFeedbacks", new[] { "Student_StudentId" });
            DropIndex("dbo.CourseFeedbacks", new[] { "CourseId" });
            DropIndex("dbo.CourseSectionAndStudents", new[] { "CourseSectionId" });
            DropIndex("dbo.CourseSectionAndStudents", new[] { "StudentId" });
            DropIndex("dbo.StudentAndStudentGroups", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentAndStudentGroups", new[] { "StudentId" });
            DropIndex("dbo.CourseSectionAndStudentGroups", new[] { "CourseSectionId" });
            DropIndex("dbo.CourseSectionAndStudentGroups", new[] { "StudentGroupId" });
            DropIndex("dbo.CourseSections", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.CourseSections", new[] { "CourseId" });
            DropIndex("dbo.CourseSectionAssignments", new[] { "CourseSectionId" });
            DropIndex("dbo.CourseSectionAssignmentAndStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseSectionAssignmentAndStudents", new[] { "CourseAssignmentId" });
            DropIndex("dbo.CourseExamAndStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseExamAndStudents", new[] { "CourseExamId" });
            DropIndex("dbo.CourseExams", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.CourseExams", new[] { "Course_CourseId" });
            DropIndex("dbo.Courses", new[] { "InstructorId" });
            DropIndex("dbo.CourseChapters", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.CourseChapters", new[] { "CourseId" });
            DropIndex("dbo.CourseChapterAndStudents", new[] { "CourseChapterId" });
            DropIndex("dbo.CourseChapterAndStudents", new[] { "StudentId" });
            DropTable("dbo.Instructors");
            DropTable("dbo.CourseFeedbacks");
            DropTable("dbo.CourseSectionAndStudents");
            DropTable("dbo.StudentAndStudentGroups");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.CourseSectionAndStudentGroups");
            DropTable("dbo.CourseSections");
            DropTable("dbo.CourseSectionAssignments");
            DropTable("dbo.CourseSectionAssignmentAndStudents");
            DropTable("dbo.Students");
            DropTable("dbo.CourseExamAndStudents");
            DropTable("dbo.CourseExams");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseChapters");
            DropTable("dbo.CourseChapterAndStudents");
        }
    }
}
