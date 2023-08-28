using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseExam
    {
        [Key]
        public int CourseExamId { get; set; }
        [Required]
        public int CourseExamName { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
        

        public virtual ICollection<CourseExamAndStudent> CourseExamStudents { get; set; }
        public CourseExam() {
            CourseExamStudents = new List<CourseExamAndStudent>();
        }
    }
}
