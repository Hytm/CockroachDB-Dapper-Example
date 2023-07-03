namespace DotNet_Dapper_CRDB.Services
{
    public interface ICRUDService<T> where T : class
    {
        Task<bool> Create(T obj);
        Task<T> Get(Guid id);
        Task<List<T>> GetList();
        Task<T> Update(T obj);
        Task<bool> Delete(Guid id);
    }
}