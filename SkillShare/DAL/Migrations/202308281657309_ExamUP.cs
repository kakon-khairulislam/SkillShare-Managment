namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamUP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseExams", "Instructor_InstructorId", "dbo.Instructors");
            DropIndex("dbo.CourseExams", new[] { "Instructor_InstructorId" });
            RenameColumn(table: "dbo.CourseExams", name: "Instructor_InstructorId", newName: "InstructorId");
            AlterColumn("dbo.CourseExams", "InstructorId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseExams", "InstructorId");
            AddForeignKey("dbo.CourseExams", "InstructorId", "dbo.Instructors", "InstructorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseExams", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.CourseExams", new[] { "InstructorId" });
            AlterColumn("dbo.CourseExams", "InstructorId", c => c.Int());
            RenameColumn(table: "dbo.CourseExams", name: "InstructorId", newName: "Instructor_InstructorId");
            CreateIndex("dbo.CourseExams", "Instructor_InstructorId");
            AddForeignKey("dbo.CourseExams", "Instructor_InstructorId", "dbo.Instructors", "InstructorId");
        }
    }
}
