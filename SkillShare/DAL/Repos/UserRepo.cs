using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, bool>,IAuth<User>
    {
        public User Auth(string name, string password)
        {
            var data = from u in db.Users
                       where u.Username.Equals(name)
                       && u.Password.Equals(password)
                       select u;
            return data.SingleOrDefault();
        }

        public bool Create(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetALL()
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
