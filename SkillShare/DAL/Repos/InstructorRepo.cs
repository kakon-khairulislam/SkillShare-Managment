using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class InstructorRepo : Repo, IRepo<Instructor, int, bool>, IAuth<Instructor>
    {
        public Instructor Auth(string name, string password)
        {
            var data = from u in db.Instructors
                       where u.InstructorEmail == name && u.InstructorPassword == password && u.InstructorAccountStatus == "Active"
                       select u;
            return data.SingleOrDefault();
        }

        public bool Create(Instructor obj)
        {
            db.Instructors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ins=Get(id);
            ins.InstructorAccountStatus = "Deleted";
            return db.SaveChanges() > 0;

        }

        public Instructor Get(int id)
        {
            var data = db.Instructors.Where(s => s.InstructorId == id && s.InstructorStatus != "Deleted");
            return data.SingleOrDefault();
        }

        public List<Instructor> GetALL()
        {
            return db.Instructors.Where(s => s.InstructorStatus != "Deleted").ToList();
        }

        public bool Update(Instructor obj)
        {
            var ins= Get(obj.InstructorId);
            ins.InstructorName = obj.InstructorName;
            ins.InstructorEmail = obj.InstructorEmail;
            ins.InstructorPassword = obj.InstructorPassword;
            ins.InstructorPhoneNumber = obj.InstructorPhoneNumber;
            ins.InstructorStatus = obj.InstructorStatus;
            ins.InstructorAccountStatus = obj.InstructorAccountStatus;
            ins.RegistrationDate = obj.RegistrationDate;
            return db.SaveChanges() > 0;
        }
    }
}
