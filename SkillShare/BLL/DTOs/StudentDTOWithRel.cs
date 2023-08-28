using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentDTOWithRel: StudentDTO
    {
        public List<StudentAndStudentGroupDTOWithRel> StudentAndStudentGroups { get; set; }
        //public ICollection<CourseSectionAndStudentGroupDTO> CourseSectionAndStudentGroups { get; set; }
        public StudentDTOWithRel() { 
            StudentAndStudentGroups = new List<StudentAndStudentGroupDTOWithRel>();
        }
    }
}
