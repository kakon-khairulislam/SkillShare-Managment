using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseChapterDTO
    {
        public int CourseChapterID { get; set; }
        
        public string CourseChapterName { get; set; }
        
        public string CourseChapterDescription { get; set; }
        
        public int CourseId { get; set; }
    }
}
