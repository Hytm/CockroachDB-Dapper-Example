namespace DotNet_Dapper_CRDB.Services
{
    public interface IDbService
    {
        Task<T> GetAsync<T>(string command, object parms); 
        Task<List<T>> GetAll<T>(string command, object parms );
        Task<int> MutateData(string command, object parms);
    }
}