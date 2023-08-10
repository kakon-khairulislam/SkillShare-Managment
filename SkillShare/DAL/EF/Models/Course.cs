using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required] 
        public string CourseName { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        [Required]
        public string CourseStartDate { get; set; }
        [Required]
        public string CourseFinishDate { get; set; }

        //Mohit Tutor entity banaila ekhana emon reference hoba
        //[ForeignKey("Tutor")] public int TutorId { get; set; }
        //public virtual Tutor Tutor { get; set; }

        [ForeignKey("Instructor")] 
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<CourseSection> CourseSections { get; set;}
        public virtual ICollection<CourseChapter> CourseChapters { get; set;}
        public virtual ICollection<CourseFeedback> CourseFeedbacks { get; set;}
        public virtual ICollection<CourseExam> CourseExams { get; set;}
        public Course()
        {
            CourseSections = new List<CourseSection>();
            CourseChapters = new List<CourseChapter>();
            CourseFeedbacks = new List<CourseFeedback>();
            CourseExams = new List<CourseExam>();
        }
    }
}
