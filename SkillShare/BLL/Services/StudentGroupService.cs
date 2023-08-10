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
    }
}
