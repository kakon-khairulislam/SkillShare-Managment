
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SkillShareContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAndStudentGroup> StudentAndStudentGroups { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseChapter> CourseChapters { get; set; }
        public DbSet<CourseChapterAndStudent> CourseChapterAndStudents { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<CourseSectionAndStudent> CourseSectionAndStudents { get; set; }
    }
}
