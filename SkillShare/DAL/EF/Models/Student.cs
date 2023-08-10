using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public string StudentPassword { get; set; }
        [Required]
        public string StudentPhoneNumber { get; set; }
        [Required]
        public string StudentStatus { get; set; }
        [Required]
        public string StudentAccountStatus { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.Now.Date;


        public virtual ICollection<StudentAndStudentGroup> StudentAndStudentGroups { get; set; }
        public virtual ICollection<CourseSectionAndStudent> CourseSectionAndStudents { get; set; }
        public virtual ICollection<CourseChapterAndStudent> CourseChapterAndStudents { get; set; }
        public virtual ICollection<CourseSectionAssignmentAndStudent> CourseAssignmentAndStudents { get; set; }
        public virtual ICollection<CourseExamAndStudent> CourseExamAndStudents { get; set; }

        public Student()
        {
            StudentAndStudentGroups = new List<StudentAndStudentGroup>();
            CourseSectionAndStudents = new List<CourseSectionAndStudent>();
            CourseChapterAndStudents = new List<CourseChapterAndStudent>();
            CourseAssignmentAndStudents = new List<CourseSectionAssignmentAndStudent>();
            CourseExamAndStudents = new List<CourseExamAndStudent>();
        }
    }
}
