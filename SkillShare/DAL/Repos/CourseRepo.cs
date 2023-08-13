using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, IRepo<Course, int, bool>
    {
        public bool Create(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var obj = db.Courses.Find(id);
            db.Courses.Remove(obj);
            return db.SaveChanges() > 0;
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public List<Course> GetALL()
        {
            return db.Courses.ToList();
        }

        public bool Update(Course obj)
        {
            var course = db.Courses.Find(obj.CourseId);
            course.CourseName = obj.CourseName;
            course.CourseDescription = obj.CourseDescription;
            course.CourseStartDate = obj.CourseStartDate;
            course.CourseFinishDate = obj.CourseFinishDate;
            course.InstructorId = obj.InstructorId;
            return db.SaveChanges() > 0;
        }
    }
}
