using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseSectionAndStudent
    {
        [Key]
        public int CousrseSectionAndStudentId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("CourseSection")]
        public int CourseSectionId { get; set; }
        public string CourseStudentProgression { get; set; } = "Unfinished";

        public virtual Student Student { get; set; }
        public virtual CourseSection CourseSection { get; set; }
    }
}
