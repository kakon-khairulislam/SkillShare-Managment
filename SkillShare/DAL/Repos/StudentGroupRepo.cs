using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentGroupRepo : Repo, IRepo<StudentGroup, int, bool>
    {
        public bool Create(StudentGroup obj)
        {
            db.StudentGroups.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var student = Get(id);
            student.GroupStatus = "Disable";
            return db.SaveChanges() > 0;
        }

        public StudentGroup Get(int id)
        {
            var data = db.StudentGroups.Where(s => s.StudentGroupId == id);
            return data.FirstOrDefault();
        }

        public List<StudentGroup> GetALL()
        {
            return db.StudentGroups.ToList();
        }

        public bool Update(StudentGroup obj)
        {
            var studentGroup = Get(obj.StudentGroupId);
            db.Entry(studentGroup).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
