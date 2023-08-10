using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseSection
    {
        [Key]
        public int CourseSectionId { get; set; }
        [Required]
        public string CourseSectionName { get; set; }
        [Required]
        public int? CourseSectionStudentLimit { get; set; } = 0;
        public int? MinimumStudentLimitGroup { get; set; } = 0;
        public int? MaximumStudentLimitGroup { get; set; } = 0;
        [ForeignKey("Course")]
        public int CourseId { get; set; }


        public virtual Course Course { get; set; }
        public virtual ICollection<CourseSectionAndStudent> CourseSectionAndStudents { get; set; }
        public virtual ICollection<CourseSectionAssignment> CourseAssignments { get; set; }
        public virtual ICollection<CourseSectionAndStudentGroup> CourseSectionAndStudentGroups { get; set; }
        public CourseSection()
        {
            CourseSectionAndStudents = new List<CourseSectionAndStudent>();
            CourseAssignments = new List<CourseSectionAssignment>();
            CourseSectionAndStudentGroups = new List<CourseSectionAndStudentGroup>();
        }
    }
}
