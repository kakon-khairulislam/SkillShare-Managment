using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace BLL.Services
{
    public class StudentAndStudentGroupService
    {
        public static StudentAndStudentGroupDTO GetStudentAndStudentGroup(int id)
        {
            return ConvertingClass<StudentAndStudentGroup, StudentAndStudentGroupDTO>.Convert(DataAccessFactory.StudentAndStudentGroupDataAccess().Get(id));
        }

        public static bool DuplicateCheck(StudentAndStudentGroupDTO studentAndStudentGroup)
        {
            return GetAllStudentAndStudentGroups().Where(
                
                   g => g.StudentId == studentAndStudentGroup.StudentId && g.StudentGroupId == studentAndStudentGroup.StudentGroupId
                
                   ).Count() > 0 ? true : false;
        }

        public static bool CreateStudentAndStudentGroup(StudentAndStudentGroupDTO studentAndStudentGroup)
        {
            return DuplicateCheck(studentAndStudentGroup) ? false : DataAccessFactory.StudentAndStudentGroupDataAccess().Create(ConvertingClass<StudentAndStudentGroupDTO, StudentAndStudentGroup>.Convert(studentAndStudentGroup));
        }
        
        public static bool CreateStudentAndStudentGroupList(List<StudentAndStudentGroupDTO> studentAndStudentGroups)
        {
            foreach (var studentGroup in studentAndStudentGroups)
            {
                var d = DataAccessFactory.StudentGroupDataAccess().Get(studentGroup.StudentGroupId);
                if (d.StudentLimit > 0)
                {
                    if (!CreateStudentAndStudentGroup(studentGroup))
                    {
                        return false;
                    }
                    var data = DataAccessFactory.StudentGroupDataAccess().Get(studentGroup.StudentGroupId);
                    data.StudentLimit -= 1;
                    DataAccessFactory.StudentGroupDataAccess().Update(data);
                }
                else { return false; }
            }
            return true;
        }
        
        public static bool DeleteStudentAndStudentGroup(List<StudentAndStudentGroupDTO> studentAndStudentGroups)
        {
            foreach(var studentGroup in studentAndStudentGroups)
            {
                if (!DataAccessFactory.StudentAndStudentGroupDataAccess().Delete(studentGroup.StudentAndStudentGroupId))
                {
                    return false;
                }
                var data = DataAccessFactory.StudentGroupDataAccess().Get(studentGroup.StudentGroupId);
                data.StudentLimit += 1;
                DataAccessFactory.StudentGroupDataAccess().Update(data);
            }
            return true;
            
        }
        
        public static int StudentSpaceInGroup(int id)
        {
            return GetAllStudentAndStudentGroups().Where(s => s.StudentGroupId == id).Count();
        }

        public static bool ModifyStudentAndStudentGroup(StudentAndStudentGroupDTO studentAndStudentGroup)
        {
            return DataAccessFactory.StudentAndStudentGroupDataAccess().Update(ConvertingClass<StudentAndStudentGroupDTO, StudentAndStudentGroup>.Convert(studentAndStudentGroup));
        }
        
        public static List<StudentAndStudentGroupDTO> GetAllStudentAndStudentGroups()
        {
            return ConvertingClass<StudentAndStudentGroupDTO, StudentAndStudentGroup>.Convert(DataAccessFactory.StudentAndStudentGroupDataAccess().GetALL().ToList()).ToList();
        }
    }
}
