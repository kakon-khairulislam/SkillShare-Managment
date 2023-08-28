using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseSectionDTO
    {
        public int CourseSectionId { get; set; }
        
        public string CourseSectionName { get; set; }
        
        public int? CourseSectionStudentLimit { get; set; } = 0;
        public int? MinimumStudentLimitGroup { get; set; } = 0;
        public int? MaximumStudentLimitGroup { get; set; } = 0;
        
        public string CourseSectionStatus { get; set; } = "Enable";
        
        public int CourseId { get; set; }
    }
}
