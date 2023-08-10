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
        public static IRepo<Student, int, bool> StudentDataAccess()
        {
            return new StudentRepo();
        }
        public static IRepo<StudentGroup, int, bool> StudentGroupDataAccess() 
        { 
            return new StudentGroupRepo(); 
        }
    }
}
