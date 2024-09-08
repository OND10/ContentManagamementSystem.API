using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Database
{
    public class ApplicationDapperContext
    {

        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public ApplicationDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            this.connectionString = _configuration.GetConnectionString("defaultConnectionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
