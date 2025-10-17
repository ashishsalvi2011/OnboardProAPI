using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interface;
using System.Data;


namespace OnboardPro.Services
{
    public class DapperContext: IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("OnboardProConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
