using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CourseFeedback
    {
        [Key]
        public int CourseFeedbackId {get; set;}
        [Required]
        public string CourseComment { get; set;}
        [Required]
        public int CourseRate { get; set;}
        [ForeignKey("Course")]
        public int CourseId { get; set;}
        public virtual Course Course { get; set;}
        public virtual Student Student { get; set;}
    }
}
