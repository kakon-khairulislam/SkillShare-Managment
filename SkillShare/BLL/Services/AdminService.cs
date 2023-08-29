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
        public static List<AdminDTO> GetAllAdmin()
        {
            var data = DataAccessFactory.AdminDataAccess().GetALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<Admin>(admin);
            return DataAccessFactory.AdminDataAccess().Create(insDTO);
            var adDTO = mapper.Map<List<AdminDTO>>(data);
            return adDTO;
        }

        public List<AdminDTO> GetAllAdmin()
        public static AdminDTO GetAdmin(int id)
        {
            DataAccessFactory.AdminDataAccess().GetALL();
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<AdminDTO>(DataAccessFactory.AdminDataAccess.);
            return DataAccessFactory.AdminDataAccess().Create(insDTO);
            var adDTO = mapper.Map<AdminDTO>(data);
            return adDTO;
        }
        public static bool CreateAdmin(AdminDTO ad)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var adDTO = mapper.Map<Admin>(ad);
            var data = DataAccessFactory.AdminDataAccess().Create(adDTO);
            return data;
        }
        public static bool UpdateAdmin(AdminDTO ad)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var adDTO = mapper.Map<Admin>(ad);
            var data = DataAccessFactory.AdminDataAccess().Update(adDTO);
            return data;
        }
        public static bool DeleteAdmin(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Delete(id);
            return data;
        }
        
    }
}
