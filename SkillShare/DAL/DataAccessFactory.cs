using DAL.EF.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
        public static IRepo<StudentAndStudentGroup, int, bool> StudentAndStudentGroupDataAccess() 
        {
            return new StudentAndStudentGroupRepo();
        }
        public static IRepo<Course, int, bool> CourseDataAccess()
        {
            return new CourseRepo();
        }
        public static IRepo<CourseSection, int, bool> CourseSectionDataAccess()
        {
            return new CourseSectionRepo();
        }
        public static IRepo<CourseSectionAndStudent, int, bool> CourseSectionAndStudentDataAccess()
        {
            return new CourseSectionAndStudentRepo();
        }
        public static IRepo<User, string, bool> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, int, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IAuth<User> AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<CourseChapter, int, bool> CourseChapterDataAccess()
        {
            return new CourseChapterRepo();
        }
        public static IRepo<CourseChapterAndStudent,int, bool> CourseChapterAndStudentDataAccess()
        {
            return new CourseChapterAndStudentRepo();
        }
    }
}
