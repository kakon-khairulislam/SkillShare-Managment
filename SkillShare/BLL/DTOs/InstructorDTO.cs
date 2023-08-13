using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class InstructorDTO
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPassword { get; set; }
        public string InstructorPhoneNumber { get; set; }
        public string InstructorStatus { get; set; }
        public string InstructorAccountStatus { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
