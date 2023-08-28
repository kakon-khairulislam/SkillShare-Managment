using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseSectionAndStudentDTO
    {
        public int CousrseSectionAndStudentId { get; set; }
        
        public int StudentId { get; set; }
        
        public int CourseSectionId { get; set; }
        public string CourseStudentProgression { get; set; } = "Unfinished";
    }
}
