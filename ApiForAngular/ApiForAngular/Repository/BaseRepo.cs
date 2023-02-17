using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForAngular.Repository
{
    public class BaseRepo
    {
        private readonly IConfiguration _configuration;
        protected BaseRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("mycon"));
        }

    }
}
