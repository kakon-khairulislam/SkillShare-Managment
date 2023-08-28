using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseChapterAndStudentDTO
    {
        public int CourseChapterAndStudentId { get; set; }
        
        public int StudentId { get; set; }
        
        public int CourseChapterId { get; set; }
        
        public string CourseChapterStudentProgression { get; set; }
    }
}
