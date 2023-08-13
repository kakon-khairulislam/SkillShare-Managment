using AutoMapper;
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
    public class CourseService
    {
        public static List<CourseDTO> GetAllCourse()
        {
            var data = DataAccessFactory.CourseDataAccess().GetALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var corDTO = mapper.Map<List<CourseDTO>>(data);
            return corDTO;
        }
        public static CourseDTO GetCourse(int id)
        {
            var data = DataAccessFactory.CourseDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var corDTO = mapper.Map<CourseDTO>(data);
            return corDTO;
        }
        public static bool CreateCourse(CourseDTO cor)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            var corDTO = mapper.Map<Course>(cor);
            var data = DataAccessFactory.CourseDataAccess().Create(corDTO);
            return data;
        }
        public static bool UpdateCourse(CourseDTO cor)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            var corDTO = mapper.Map<Course>(cor);
            var data = DataAccessFactory.CourseDataAccess().Update(corDTO);
            return data;
        }
        public static bool DeleteCourse(int id)
        {
            var data = DataAccessFactory.CourseDataAccess().Delete(id);
            return data;
        }
        public static List<CourseDTO> GetALLCourseByInstructor(int id)
        {
            var data = DataAccessFactory.CourseDataAccess().GetALL().Where(x => x.InstructorId == id).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var corDTO = mapper.Map<List<CourseDTO>>(data);
            return corDTO;
        }
    }
}
