using DAL.EF.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Instructor, int, bool> InstructorDataAccess()
        {
            return new InstructorRepo();
        }
        public static IRepo<Course, int, bool> CourseDataAccess()
        {
            return new CourseRepo();
        }
    }
}
