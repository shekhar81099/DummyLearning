using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<T> GenericQuery<T>(string query, T parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand(query, connection))
                    {

                        // Add parameters to prevent SQL Injection
                        // command.Parameters.AddWithValue("@UserId", userId);
                        // command.Parameters.AddWithValue("@Age", newAge);

                        // Execute the command
                        var data = command.ExecuteReader();

                        if (data.HasRows)
                        {
                            while (data.Read())
                            {
                                // Read the data
                                var userId = data["UserId"];
                                var age = data["Age"];
                            }
                        }
                        return default(T);
                    }
                }
                catch (Exception ex)
                {
                    // Log.Error(ex, "Error in GenericQuery");
                    return default(T);
                }
            }
        }
    }
}