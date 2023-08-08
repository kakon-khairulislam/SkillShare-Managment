using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseChapterAndStudent
    {
        [Key]
        public int CourseChapterAndStudentId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("CourseChapter")]
        public int CourseChapterId { get; set; }
        [Required]
        public string CourseChapterStudentProgression { get; set; } = "Unfinished";

        public virtual Student Student { get; set; }
        public virtual CourseChapter CourseChapter { get; set; }
    }
}
