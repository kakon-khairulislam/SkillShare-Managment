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
    public class AuthService
    {
        public static TokenDTO Login(string Username, string Password)
        {
            var data = DataAccessFactory.AuthDataAccess().Auth(Username, Password);
            if (data != null)
            {
                var token = new Token();
                token.Username = data.UserId;
                token.TokenKey = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccessFactory.TokenDataAccess().Create(token);

                var ret = ConvertingClass<Token, TokenDTO>.Convert(tk);

                return ret;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetALL()
                      where t.TokenKey.Equals(token)
                      && (t.ExpiredAt == null || t.ExpiredAt>DateTime.Now)
                      select t).SingleOrDefault();
            
            if (tk != null)
            {
                return true;
            }
            return false;
        }
        public static bool CheckType(string token,string typ)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetALL()
                      where t.TokenKey.Equals(token)
                      && t.User.type == typ
                      select t).SingleOrDefault();

            if (tk != null)
            {
                return true;
            }
            return false;
        }
    }
}
