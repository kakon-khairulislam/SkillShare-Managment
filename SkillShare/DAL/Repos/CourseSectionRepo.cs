using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseSectionRepo : Repo, IRepo<CourseSection, int, bool>
    {
        public bool Create(CourseSection obj)
        {
            db.CourseSections.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            data.CourseSectionStatus ="Disabled";
            return Update(data);
        }

        public CourseSection Get(int id)
        {
            return db.CourseSections.Find(id);
        }

        public List<CourseSection> GetALL()
        {
            return db.CourseSections.ToList();
        }

        public bool Update(CourseSection obj)
        {
            db.Entry(Get(obj.CourseSectionId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0; ;
        }
    }
}
