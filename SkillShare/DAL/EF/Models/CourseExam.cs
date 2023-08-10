using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        

        public virtual ICollection<CourseExamAndStudent> CourseExamStudents { get; set; }
        public CourseExam() {
            CourseExamStudents = new List<CourseExamAndStudent>();
        }
    }
}
