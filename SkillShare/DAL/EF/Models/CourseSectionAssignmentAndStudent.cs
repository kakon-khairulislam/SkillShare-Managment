using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseSectionAssignmentAndStudent
    {
        [Key]
        public int CourseAssignmentAndStudentId { get; set; }
        [Required]
        public string StudentAssignmentStatus { get; set; }
        [ForeignKey("CourseAssignment")]
        public int CourseAssignmentId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual CourseSectionAssignment CourseAssignment { get; set; }
    }
}
