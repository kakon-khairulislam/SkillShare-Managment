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
        /*public static List<InstructorDTO> GetALLInsByCourse(int id)
        {
            var data = DataAccessFactory.InstructorDataAccess().GetALL().Where(x => x.CourseId == id).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<List<InstructorDTO>>(data);
            return insDTO;
        }*/
    }
}
