using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class ConvertingClass<CLASS_A, CLASS_B>
    {
        public static CLASS_A Convert(CLASS_B obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CLASS_B, CLASS_A>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<CLASS_A>(obj);
            return ret;
        }

        public static CLASS_B Convert(CLASS_A obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CLASS_A, CLASS_B>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<CLASS_B>(obj);
            return ret;
        }

        public static List<CLASS_A> Convert(List<CLASS_B> obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CLASS_B, CLASS_A>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<CLASS_A>>(obj);
            return ret;
        }
        public static List<CLASS_B> Convert(List<CLASS_A> obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CLASS_A, CLASS_B>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<CLASS_B>>(obj);
            return ret;
        }
    }
}
