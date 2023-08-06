using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ProjectManagementContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project_Members> Project_Members { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
