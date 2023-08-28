using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class StudentGroup
    {
        [Key]
        public int StudentGroupId { get; set; }
        [Required] 
        public string StudentGroupName { get; set; }
        [Required]
        public int StudentLimit { get; set;}
        [Required]
        public string AllStudentStatus { get; set; }
        [Required]
        public string GroupStatus { get; set; } = "Enable";
        [Required]
        public DateTime GroupCreationDate { get; set; } = DateTime.Now.Date;


        public virtual ICollection<StudentAndStudentGroup> StudentAndStudentGroups { get; set; }
        public virtual ICollection<CourseSectionAndStudentGroup> CourseSectionAndStudentGroups { get; set; }

        public StudentGroup()
        {
            StudentAndStudentGroups = new List<StudentAndStudentGroup>();
            CourseSectionAndStudentGroups = new List<CourseSectionAndStudentGroup>();
        }
    }
}
