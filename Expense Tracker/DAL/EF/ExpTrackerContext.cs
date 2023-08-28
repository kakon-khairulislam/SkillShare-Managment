using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace DAL.EF
{
    public class ExpTrackerContext
    {
        private readonly IConfiguration _configuration;

        private readonly string? _connectionString;

        public ExpTrackerContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings: ExpTrackerCon"];
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
