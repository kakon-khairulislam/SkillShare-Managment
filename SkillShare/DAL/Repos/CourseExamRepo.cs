using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseExamRepo : Repo, IRepo<CourseExam, int, bool>
    {
        public bool Create(CourseExam obj)
        {
            db.CourseExams.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.CourseExams.Remove(data);
            return db.SaveChanges() > 0;
        }

        public CourseExam Get(int id)
        {
            return db.CourseExams.Find(id);
        }

        public List<CourseExam> GetALL()
        {
            return db.CourseExams.ToList();
        }

        public bool Update(CourseExam obj)
        {
            var data = Get(obj.CourseExamId);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
