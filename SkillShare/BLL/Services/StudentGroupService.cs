using AutoMapper.Internal;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentGroupService
    {
        public static bool CreateStudentGroup(StudentGroupDTO studentGroup)
        {
            return DataAccessFactory.StudentGroupDataAccess().Create(ConvertingClass<StudentGroupDTO, StudentGroup>.Convert(studentGroup));
        }
        public static bool DeleteStudentGroup(StudentGroupDTO studentGroup)
        {
            return DataAccessFactory.StudentGroupDataAccess().Delete(studentGroup.StudentGroupId);
        }
        public static bool ModifyStudentGroup(StudentGroupDTO studentGroup)
        {
            return DataAccessFactory.StudentGroupDataAccess().Update(ConvertingClass<StudentGroupDTO, StudentGroup>.Convert(studentGroup));
        }
        public static List<StudentGroupDTO> GetAllStudentGroups()
        {
            return ConvertingClass<StudentGroupDTO, StudentGroup>.Convert(DataAccessFactory.StudentGroupDataAccess().GetALL().ToList()).ToList();
        }
        public static List<StudentGroupDTO> GetEnableStudentGroups()
        {
            return GetAllStudentGroups().Where(s => s.GroupStatus == "Enable").ToList();
        }
        public static String AllStudentsPresence(int id)
        {
            return GetAllStudentGroups().Where(item=>item.StudentGroupId == id && item.AllStudentStatus == "Logged in").ToList().Count()>0? "Everyone Present": "Not Everyone Present";
        }
        public static List<StudentDTO> StudentsOfGroupById(int id)
        {
            var StudentList = new List<StudentDTO>();
            var cmp = DataAccessFactory.StudentAndStudentGroupDataAccess().GetALL().Where(item => item.StudentGroup.StudentGroupId == id);
            foreach (var student in DataAccessFactory.StudentDataAccess().GetALL())
            {
                foreach(var c in cmp)
                {
                    if(c.StudentId == student.StudentId) 
                    { 
                        StudentList.Add(ConvertingClass<Student,StudentDTO>.Convert(student));
                        cmp = cmp.Where(item => item.StudentId != c.StudentId);
                        break; 
                    }
                }
            }
            return StudentList;
        }
        public static List<StudentGroupDTO> GetStudentGroupsByName(string name)
        {
            return GetAllStudentGroups().Where(item=>item.StudentGroupName.Equals(name)).ToList();
        }
    }
}
