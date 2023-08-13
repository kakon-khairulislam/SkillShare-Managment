using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class StudentAndStudentGroup
    {
        [Key]
        public int StudentAndStudentGroupId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentGroup")]
        public int StudentGroupId { get; set; }

        public virtual Student Student { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }
}
