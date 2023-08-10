using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentDTO
    {
        
        public int StudentId { get; set; }
        
        public string StudentName { get; set; }
        
        public string StudentEmail { get; set; }
        
        public string StudentPassword { get; set; }
        
        public string StudentPhoneNumber { get; set; }
        
        public string StudentStatus { get; set; }
        
        public string StudentAccountStatus { get; set; }
        
        public DateTime RegistrationDate { get; set; } = DateTime.Now.Date;
    }
}
