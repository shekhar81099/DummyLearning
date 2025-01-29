using Dapper;
using Microsoft.Data.SqlClient;
namespace testapi.Data
{
    public class DataAccessUsingDapper
    {
        private string connectionString = string.Empty;
        private Serilog.ILogger _logger;

        // private IConfiguration _configuration;
        public DataAccessUsingDapper(IConfiguration configuration)
        {
            _logger = Serilog.Log.ForContext<DataAccessUsingDapper>();
            // _configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<T>> GenericQuery<T>(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    IEnumerable<T> result = connection.Query<T>(query);
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error in GenericQuery");
                    return null;
                }
            }

        }
    }
}