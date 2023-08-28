using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentGroupDTOWithRel: StudentGroupDTO
    {
        public List<StudentAndStudentGroupDTOWithRel> StudentAndStudentGroups { get; set; }
        public StudentGroupDTOWithRel() {
            StudentAndStudentGroups = new List<StudentAndStudentGroupDTOWithRel>();
        }
    }
}
