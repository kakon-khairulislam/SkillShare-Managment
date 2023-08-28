using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseSectionAndStudentRepo : Repo, IRepo<CourseSectionAndStudent, int, bool>
    {
        public bool Create(CourseSectionAndStudent obj)
        {
            db.CourseSectionAndStudents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.CourseSectionAndStudents.Remove(Get(id));
            return db.SaveChanges()>0;
        }

        public CourseSectionAndStudent Get(int id)
        {
            return db.CourseSectionAndStudents.Find(id);
        }

        public List<CourseSectionAndStudent> GetALL()
        {
            return db.CourseSectionAndStudents.ToList();
        }

        public bool Update(CourseSectionAndStudent obj)
        {
            db.Entry(Get(obj.CousrseSectionAndStudentId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
