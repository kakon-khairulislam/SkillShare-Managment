using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentAndStudentGroupDTO
    {
        public int StudentAndStudentGroupId { get; set; }

        public int StudentId { get; set; }

        public int StudentGroupId { get; set; }
    }
}
