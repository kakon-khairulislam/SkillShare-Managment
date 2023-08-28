using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseFeedBackRepo : Repo, IRepo<CourseFeedback, string, bool>
    {
        public bool Create(CourseFeedback obj)
        {
            db.CourseFeedbacks.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            db.CourseFeedbacks.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public CourseFeedback Get(string id)
        {
            return db.CourseFeedbacks.Find(id);
        }

        public List<CourseFeedback> GetALL()
        {
            return db.CourseFeedbacks.ToList();
        }

        public bool Update(CourseFeedback obj)
        {
            var data = db.CourseFeedbacks.Find(obj.CourseId);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
