using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseChapterRepo : Repo, IRepo<CourseChapter, int, bool>
    {
        public bool Create(CourseChapter obj)
        {
            db.CourseChapters.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseChapter Get(int id)
        {
            return db.CourseChapters.Find(id);
        }

        public List<CourseChapter> GetALL()
        {
            return db.CourseChapters.ToList();
        }

        public bool Update(CourseChapter obj)
        {
            db.Entry(Get(obj.CourseChapterID)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
