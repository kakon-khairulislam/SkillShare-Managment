using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseSectionAssignment
    {
        [Key]
        public int CourseAssignmentId { get; set; }
        [Required]
        public string CourseAssignmentName { get; set; }
        [Required]
        public string CourseAssignmentDescription { get; set; }
        [Required]
        public DateTime CourseAssignmentDueDate { get; set; }
        [Required]
        public string CourseAssignmentStatus { get; set; } = "Open";
        [ForeignKey("CourseSection")]
        public int CourseSectionId { get; set; }

        
        public virtual CourseSection CourseSection { get; set; }
        public virtual ICollection<CourseSectionAssignmentAndStudent> CourseAssignmentAndStudents { get; set; }
        public CourseSectionAssignment()
        {
            CourseAssignmentAndStudents = new List<CourseSectionAssignmentAndStudent>();
        }
    }
}
