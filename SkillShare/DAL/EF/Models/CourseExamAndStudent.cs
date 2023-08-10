using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseExamAndStudent
    {
        [Key]
        public int CourseExamAndStudentId { get; set; }
        [ForeignKey("CourseExam")]
        public int CourseExamId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public double? Grade { get; set; }


        public virtual CourseExam CourseExam { get; set; }
        public virtual Student Student { get; set; }
    }
}
