using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static bool CreateStudent(StudentDTO studentDTO)
        {
            return DataAccessFactory.StudentDataAccess().Create(ConvertingClass<StudentDTO, Student>.Convert(studentDTO));
        }
        public static bool DeleteStudent(StudentDTO studentDTO)
        {
            return DataAccessFactory.StudentDataAccess().Delete(studentDTO.StudentId);
        }
        public static bool ModifyStudent(StudentDTO studentDTO)
        {
            return DataAccessFactory.StudentDataAccess().Update(ConvertingClass<StudentDTO,Student>.Convert(studentDTO));
        }
        public static List<StudentDTO> GetAllStudents()
        {
            return ConvertingClass<Student,StudentDTO>.Convert(DataAccessFactory.StudentDataAccess().GetALL().ToList()).ToList();
        }
        public static List<StudentDTO> GetEnableStudents()
        {
            return GetAllStudents().Where(s => s.StudentAccountStatus == "Enable").ToList();
        }
    }
}
