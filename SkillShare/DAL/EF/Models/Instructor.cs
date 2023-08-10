using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPassword { get; set; }
        public string InstructorPhoneNumber { get; set; }
        public string InstructorStatus { get; set; }
        public string InstructorAccountStatus { get; set; }
        public DateTime RegistrationDate { get; set; } 

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
        public virtual ICollection<CourseChapter> CourseChapters { get; set; }
        public virtual ICollection<CourseFeedback> CourseFeedbacks { get; set; }
        public virtual ICollection<CourseExam> CourseExams { get; set; }

        public Instructor()
        {
            Courses = new List<Course>();
            CourseSections = new List<CourseSection>();
            CourseChapters = new List<CourseChapter>();
            CourseFeedbacks = new List<CourseFeedback>();
            CourseExams = new List<CourseExam>();
        }
    }
}
