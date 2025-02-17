using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace testapi.Data
{
    public class DataAccessUsingADODotnet
    {
        private string connectionString = string.Empty;
        // private IConfiguration _configuration;
        public DataAccessUsingADODotnet(IConfiguration configuration)
        {
            // _configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<T>> GenericQuery<T>(string query, Dictionary<string, object>? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(query);


            }
        }
    }
}