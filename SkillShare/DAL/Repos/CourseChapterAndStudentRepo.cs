using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseChapterAndStudentRepo : Repo, IRepo<CourseChapterAndStudent, int, bool>
    {
        public bool Create(CourseChapterAndStudent obj)
        {
            db.CourseChapterAndStudents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseChapterAndStudent Get(int id)
        {
            return db.CourseChapterAndStudents.Find(id);
        }

        public List<CourseChapterAndStudent> GetALL()
        {
            return db.CourseChapterAndStudents.ToList();
        }

        public bool Update(CourseChapterAndStudent obj)
        {
            db.Entry(Get(obj.CourseChapterAndStudentId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
