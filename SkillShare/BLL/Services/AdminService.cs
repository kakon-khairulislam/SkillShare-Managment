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
    public class AdminService
    {
        public bool CreateAdmin(AdminDTO admin)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<Admin>(admin);
            return DataAccessFactory.AdminDataAccess().Create(insDTO);
        }

        public List<AdminDTO> GetAllAdmin()
        {
            DataAccessFactory.AdminDataAccess().GetALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<AdminDTO>(DataAccessFactory.AdminDataAccess.);
            return DataAccessFactory.AdminDataAccess().Create(insDTO);
        }
    }
}
