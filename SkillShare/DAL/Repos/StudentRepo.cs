using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo : Repo, IRepo<Student, int, bool>
    {
        public bool Create(Student obj)
        {
            db.Students.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var student = Get(id);
            student.StudentAccountStatus = "Disable";
            return db.SaveChanges() > 0;
        }

        public Student Get(int id)
        {
            var data = db.Students.Where(s=>s.StudentId == id);
            return data.FirstOrDefault();
        }

        public List<Student> GetALL()
        {
            return db.Students.ToList();
        }

        public bool Update(Student obj)
        {
            var student = Get(obj.StudentId);
            db.Entry(student).CurrentValues.SetValues(obj);
            return db.SaveChanges()>0;
        }
    }
}
