using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentAndStudentGroupRepo : Repo, IRepo<StudentAndStudentGroup, int, bool>
    {
        public bool Create(StudentAndStudentGroup obj)
        {
            db.StudentAndStudentGroups.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool CreateList(List<StudentAndStudentGroup> objs)
        {
            foreach (StudentAndStudentGroup obj in objs)
            {
                if (!Create(obj))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Delete(int id)
        {
            var student = Get(id);
            db.StudentAndStudentGroups.Remove(student);
            return db.SaveChanges() > 0;
        }

        public StudentAndStudentGroup Get(int id)
        {
            return db.StudentAndStudentGroups.Find(id);
        }

        public List<StudentAndStudentGroup> GetALL()
        {
            return db.StudentAndStudentGroups.ToList();
        }

        public bool Update(StudentAndStudentGroup obj)
        {
            db.Entry(Get(obj.StudentAndStudentGroupId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
