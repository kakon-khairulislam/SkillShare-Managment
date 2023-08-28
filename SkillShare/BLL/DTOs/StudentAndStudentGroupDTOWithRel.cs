using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentAndStudentGroupDTOWithRel: StudentAndStudentGroupDTO
    {
        public StudentDTO Student { get; set; }
        public StudentGroupDTO StudentGroup { get; set; }
    }
}
