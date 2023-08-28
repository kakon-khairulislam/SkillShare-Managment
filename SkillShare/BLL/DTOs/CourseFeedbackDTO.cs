using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseFeedbackDTO
    {
        public string CourseComment { get; set; }
        public int CourseRate { get; set; }
        public int CourseId { get; set; }
    }
}
