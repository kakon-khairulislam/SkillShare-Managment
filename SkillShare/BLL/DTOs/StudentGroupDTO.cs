using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentGroupDTO
    {
        public int StudentGroupId { get; set; }
        
        public string StudentGroupName { get; set; }

        public int StudentLimit { get; set; }

        public string AllStudentStatus { get; set; }
        
        public string GroupStatus { get; set; }
        
        public DateTime GroupCreationDate { get; set; } = DateTime.Now.Date;
    }
}
