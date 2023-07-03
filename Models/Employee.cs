namespace DotNet_Dapper_CRDB.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Department { get; set; }
}