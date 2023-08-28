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
            var data = Get(id);
            data.CourseStauts = "Disabled";
            return Update(data);
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
            db.Entry(Get(obj.CourseId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
