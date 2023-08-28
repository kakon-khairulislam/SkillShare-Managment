using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseExamAndStudentRepo : Repo, IRepo<CourseExamAndStudent, int, bool>
    {
        public bool Create(CourseExamAndStudent obj)
        {
            db.CourseExamsAndStudents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.CourseExamsAndStudents.Remove(data);
            return db.SaveChanges() > 0;
        }

        public CourseExamAndStudent Get(int id)
        {
            return db.CourseExamsAndStudents.Find(id);
        }

        public List<CourseExamAndStudent> GetALL()
        {
            return db.CourseExamsAndStudents.ToList();
        }

        public bool Update(CourseExamAndStudent obj)
        {
            var data = Get(obj.CourseExamAndStudentId);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
