using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        
        public int CourseId { get; set; }
        
        public string CourseName { get; set; }
        
        public string CourseDescription { get; set; }
        
        public string Difficulty { get; set; }
        
        public string Tag { get; set; }
        
        public string CourseStartDate { get; set; }
        
        public string CourseFinishDate { get; set; }
        
        public string CourseStauts { get; set; }
    }
}
