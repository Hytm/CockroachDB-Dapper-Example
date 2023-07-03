using System.Data;
using Dapper;
using Npgsql;

namespace DotNet_Dapper_CRDB.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _dbConnection;
        public DbService(IConfiguration configuration)
        {
            _dbConnection = new NpgsqlConnection(configuration.GetConnectionString("Employeedb"));
        }
        public async Task<T> GetAsync<T>(string command, object parms)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(command, parms);
        }
        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            return (await _dbConnection.QueryAsync<T>(command, parms)).ToList();
        }
        public async Task<int> MutateData(string command, object parms)
        {
            return await _dbConnection.ExecuteAsync(command, parms);
        }
    }
}