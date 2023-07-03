using DotNet_Dapper_CRDB.Models;

namespace DotNet_Dapper_CRDB.Services;

public class EmployeeService : ICRUDService<Employee>
{
    private readonly IDbService _dbService;
    public EmployeeService(IDbService dbService)
    {
        _dbService = dbService;
    }
    public async Task<bool> Create(Employee obj)
    {
        var command = @"INSERT INTO Employee (Name, Age, Address, Department) VALUES (@Name, @Age, @Address, @Department)";
        var parms = new { obj.Id, obj.Name, obj.Age, obj.Address, obj.Department };
        var result = await _dbService.MutateData(command, parms);
        return result > 0;
    }
    public async Task<Employee> Get(Guid id)
    {
        var command = @"SELECT * FROM Employee WHERE Id = @Id";
        var parms = new { Id = id };
        return await _dbService.GetAsync<Employee>(command, parms);
    }
    public async Task<List<Employee>> GetList()
    {
        var command = @"SELECT * FROM Employee LIMIT 100";
        var parms = new { };
        return await _dbService.GetAll<Employee>(command, parms);
    }
    public async Task<Employee> Update(Employee obj)
    {
        var command = @"UPDATE Employee SET Name = @Name, Age = @Age, Address = @Address, Department = @Department WHERE Id = @Id";
        var parms = new { obj.Id, obj.Name, obj.Age, obj.Address, obj.Department };
        var result = await _dbService.MutateData(command, parms);
        return result > 0 ? obj : null;
    }
    public async Task<bool> Delete(Guid id)
    {
        var command = @"DELETE FROM Employee WHERE Id = @Id";
        var parms = new { Id = id };
        var result = await _dbService.MutateData(command, parms);
        return result > 0;
    }
}