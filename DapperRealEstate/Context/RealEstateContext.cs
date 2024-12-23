using System.Data;
using System.Data.SqlClient;

namespace DapperRealEstate.Context
{
    public class RealEstateContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public RealEstateContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection()=>new SqlConnection(_connectionString);
    }
}
