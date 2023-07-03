using Microsoft.AspNetCore.Mvc;
using DotNet_Dapper_CRDB.Services;
using DotNet_Dapper_CRDB.Models;

namespace DotNet_Dapper_CRDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ICRUDService<Employee> _crudService;
        public EmployeesController(ICRUDService<Employee> crudService)
        {
            _crudService = crudService;
        }
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _crudService.GetList();
        }
        [HttpGet("{id:Guid}")]
        public async Task<Employee> Get(Guid id)
        {
            return await _crudService.Get(id);
        }
        [HttpPost]
        public async Task<bool> AddEmployee([FromBody]Employee employee)
        {
            return await _crudService.Create(employee);
        }
        [HttpPut]
        public async Task<Employee> UpdateEmployee([FromBody]Employee employee)
        {
            return await _crudService.Update(employee);
        }
        [HttpDelete("{id:Guid}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _crudService.Delete(id);
        }
    }
}