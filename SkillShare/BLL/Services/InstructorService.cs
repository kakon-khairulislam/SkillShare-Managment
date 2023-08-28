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
    public class InstructorService
    {
        public static bool CreateIns(InstructorDTO ins)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InstructorDTO, Instructor>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<Instructor>(ins);
            var data = DataAccessFactory.InstructorDataAccess().Create(insDTO);
            return data;
        }
        public static bool DeleteIns(int id)
        {
            var data = DataAccessFactory.InstructorDataAccess().Delete(id);
            return data;
        }
        public static bool UpdateIns(InstructorDTO ins)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InstructorDTO, Instructor>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<Instructor>(ins);
            var data = DataAccessFactory.InstructorDataAccess().Update(insDTO);
            return data;
        }
        public static InstructorDTO GetIns(int id)
        {
            var data = DataAccessFactory.InstructorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<InstructorDTO>(data);
            return insDTO;
        }
        public static List<InstructorDTO> GetALLIns()
        {
            var data = DataAccessFactory.InstructorDataAccess().GetALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<List<InstructorDTO>>(data);
            return insDTO;
        }

        //Feature API
        public static List<InstructorDTO> GetALLInsByCourse(int id)
        {
            var data = (from ins in DataAccessFactory.InstructorDataAccess().GetALL()
                        join c in DataAccessFactory.CourseDataAccess().GetALL() on ins.InstructorId equals c.InstructorId
                        where c.CourseId == id
                        select ins).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<List<InstructorDTO>>(data);
            return insDTO;
        }
        public static int GetNumberOfSudentInCourse(int id)
        {
            var data= DataAccessFactory.CourseSectionAndStudentDataAccess().GetALL().Where(item=> item.CourseSection.Course.InstructorId==id).ToList();
            var dump = data.Count();
            return dump;
        }
        public static List<CourseFeedbackDTO> GetCourseFeedback(int id)
        {
            var data = (from ins in DataAccessFactory.InstructorDataAccess().GetALL()
                        join c in DataAccessFactory.CourseDataAccess().GetALL() on ins.InstructorId equals c.InstructorId
                        join cs in DataAccessFactory.CourseFeedbackDataAccess().GetALL() on c.CourseId equals cs.CourseId
                        where c.CourseId == id
                        select cs).ToList();
            var ret = ConvertingClass<CourseFeedback, CourseFeedbackDTO>.Convert(data).ToList();
            return ret;
        }
    }
}
