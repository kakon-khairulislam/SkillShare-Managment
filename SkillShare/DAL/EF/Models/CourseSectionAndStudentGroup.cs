using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseSectionAndStudentGroup
    {
        [Key]
        public int CourseSectionAndStudentGroupId { get; set; }
        [ForeignKey("StudentGroup")]
        public int StudentGroupId { get; set; }
        [ForeignKey("CourseSection")]
        public int CourseSectionId { get; set; }


        public virtual CourseSection CourseSection { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }
}
