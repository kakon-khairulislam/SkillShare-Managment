using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseChapter
    {
        [Key]
        public int CourseChapterID { get; set; }
        [Required]
        public string CourseChapterName { get; set; }
        [Required]
        public string CourseChapterDescription { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }


        public virtual Course Course { get; set; }
        public virtual ICollection<CourseChapterAndStudent> CourseChapterAndStudents { get; set; }
        public CourseChapter()
        {
            CourseChapterAndStudents = new List<CourseChapterAndStudent>();
        }
    }
}
